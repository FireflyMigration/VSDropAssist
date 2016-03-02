using System;
using System.IO;
using Autofac;
using log4net;
using log4net.Config;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using VSDropAssist.DropActions;
using VSDropAssist.DropInfoHandlers;
using VSDropAssist.Options;
using VSDropAssist.Settings;

namespace VSDropAssist
{
    public static class Application
    {
        private static IContainer _container;
        private static readonly bool _initialised = false;

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
        }

        private static void initSettings()
        {
            Settings = SettingsHelper.LoadSettingsFromStorage();
            if (Settings == null)
            {
                Settings = VSDropSettings.Default;
                
            }
        }

        public static VSDropSettings Settings { get; set; }

        private static void initIoC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SmartDropAction>().As<IDropAction>();
            builder.RegisterType<GraphModelDropInfoHandler>().As<IDropInfoHandler>();
            builder.RegisterType<DropHandler>().As<IDropHandler>();
            builder.RegisterType<ProjectItemDropInfoHandler>().As<IDropInfoHandler>();
            builder.RegisterType<FormatExpressionService>().As<IFormatExpressionService>();

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
            Settings = VSDropSettings.Default;
            SettingsHelper.SaveToStorage(Settings);

        }
    }
}