using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Autofac;
using Autofac.Core;
using EnvDTE;
using log4net;
using log4net.Config;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using Microsoft.VisualStudio.Text.Operations;
using VSDropAssist.DropActions;
using VSDropAssist.DropInfoHandlers;
using VSDropAssist.Options;
using VSDropAssist.Settings;
using VSDropAssist.Core;
using VSDropAssist.VisualStudio;

namespace VSDropAssist
{
    public static class Application
    {
        private static IContainer _container;
        private static readonly bool _initialised = false;
        public static Lazy<IVsSolution> Solution;
        public static Lazy<DTE> DTE;
        public static IEditorOperationsFactoryService EditorOperationsFactoryService;
        public static ISmartIndentationService SmartIndentationService;
        private static VSDropSettings _settings;
        private static DropActionProvider _configureddropActionProvider;

        static Application()
        {
            Init();
        }

        public static void Init()
        {
            if (_initialised) return;
            initLogging();
            initIoC();
            initSettings();
            Solution =
               new Lazy<IVsSolution>(() => Package.GetGlobalService(typeof(IVsSolution)) as IVsSolution);
            DTE = new Lazy<DTE>(()=> Package.GetGlobalService(typeof(DTE)) as DTE );
            SmartIndentationService =
                Package.GetGlobalService(typeof (ISmartIndentationService)) as ISmartIndentationService;
        }

        private static void initSettings()
        {
            Settings = SettingsHelper.LoadSettingsFromStorage();
            if (Settings == null)
            {
                Settings = new VSDropSettings();
            }
            if(Settings.Settings == null || !Settings.Settings.Any()) { 
            Settings.Settings = new List<DropActionConfiguration>(getDefaultConfigurations()) ;
                SettingsHelper.SaveToStorage(Settings);
            }
        }

        private static IEnumerable<DropActionConfiguration> getDefaultConfigurations()
        {
            var ret = new List<DropActionConfiguration>();

            ret.Add(new DropActionConfiguration() { Name="test1"});
            return ret;
        }

        public static VSDropSettings Settings
        {
            get { return _settings; }
            private set
            {
                _settings = value;
                resetDropActionProvider();
            }
        }

        private static void resetDropActionProvider()
        {
            _configureddropActionProvider = null;
        }


        private static ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();
            registerDropActions(builder);
            builder.Register(cfg => getDropActionProvider(cfg)).As<IDropActionProvider>();
           builder.RegisterType<SmartDropAction>().As<IDropAction>();
            builder.RegisterType<GraphModelDropInfoHandler>().As<IDropInfoHandler>();
            builder.RegisterType<DropHandler>().As<IDropHandler>();
            builder.RegisterType<ProjectItemDropInfoHandler>().As<IDropInfoHandler>();
            builder.RegisterType<FormatExpressionService>().As<IFormatExpressionService>();
            builder.RegisterAssemblyTypes(typeof (VSLine).Assembly).AsImplementedInterfaces();
            builder.Register(context =>
            {
                return Application.SmartIndentationService;
            }).As<ISmartIndentationService>().InstancePerDependency();

            return builder;
        }

        
        private static IDropActionProvider getDropActionProvider(IComponentContext componentContext)
        {
            if (_configureddropActionProvider == null)
            {

                _configureddropActionProvider = new DropActionProvider(createDropActionsFromSettings());
            }
            return _configureddropActionProvider;
        }

        private static IEnumerable<IConfigurableDropAction> createDropActionsFromSettings()
        {
            var settings = Application.Settings;
            if (settings != null && settings.Settings!=null)
            {
                IFormatExpressionService formatExpressionService = Application.Resolve<IFormatExpressionService>();
                IIndentationService indentationService = Application.Resolve<IIndentationService>();
                return settings.Settings.Select(x => new ConfigurableDropAction(formatExpressionService, x, indentationService));

            }
            return null;
        }

        internal static T ResolveView<T>(IWpfTextView view)
        {
            var typedParameters = new TypedParameter(typeof (IWpfTextView), view);
            return _container.Resolve<T>(typedParameters);
        }
        internal static T Resolve<T>(params object[] args )
        {
            
            var typedParameters = args.Select(x => new TypedParameter(x.GetType(), x)).ToArray();
            return _container.Resolve<T>(typedParameters);

        
        }

        internal  static void registerDropActions(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (DropActionProvider).Assembly)
                .AssignableTo<IConfigurableDropAction>().Except<ConfigurableDropAction>()
                .As<IConfigurableDropAction>();
        }

        private static void initIoC()
        {
            var builder = CreateContainerBuilder();

            _container = builder.Build();
        }

        public static IDropHandler GetDropHandler(IWpfTextView textView)

        {
            return _container.Resolve<IDropHandler>(new TypedParameter(typeof (IWpfTextView), textView));
        }

        public static IDropHandler GetProjectItemDropHandler(IWpfTextView textView)
        {
            return null;
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        private static void initLogging()
        {
            var appFolder = Path.GetDirectoryName(typeof (Application).Assembly.Location);

            var filepath = Path.Combine(appFolder , "logging.config.xml");

            var fi = new FileInfo(filepath);
            if (!fi.Exists) throw new FileNotFoundException("logging.config");
            
            XmlConfigurator.ConfigureAndWatch(fi);
            LogManager.GetLogger(typeof(Application)).Debug("Logging Started");

        }

        public static void ResetSettings()
        {
            Settings = new VSDropSettings();
            SettingsHelper.SaveToStorage(Settings);

        }

        public static void SaveSettingsToStorage()
        {
            SettingsHelper.SaveToStorage(Application.Settings);

        }

        public static void LoadSettingsFromStorage()
        {
            var tempSettinsg= SettingsHelper.LoadSettingsFromStorage();

            if (Application.Settings == null) Application.Settings = tempSettinsg;
            else
            {
                // merge the settings;

            }
        }
    }
}