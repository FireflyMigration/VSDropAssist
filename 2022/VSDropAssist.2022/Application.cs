﻿using System;
using System.IO;
using Autofac;
using EnvDTE;
using log4net;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using Microsoft.VisualStudio.Text.Operations;
using VSDropAssist.DropActions;
using VSDropAssist.DropInfoHandlers;

using VSDropAssist.Settings;
using log4net.Repository.Hierarchy;
using log4net.Appender;
using log4net.Core;
using FireflyCommunity.Core.Logging;
using System.Reflection;

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
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();

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
        }

        public static VSDropSettings Settings { get; set; }

        
        private static ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();
            registerDropActions(builder);
            builder.RegisterType<DropActionProvider>().As<IDropActionProvider>();
            builder.RegisterType<SmartDropAction>().As<IDropAction>();
            builder.RegisterType<GraphModelDropInfoHandler>().As<IDropInfoHandler>();
            builder.RegisterType<DropHandler>().As<IDropHandler>();
            builder.RegisterType<ProjectItemDropInfoHandler>().As<IDropInfoHandler>();
            builder.RegisterType<FormatExpressionService>().As<IFormatExpressionService>();

            return builder;
        }
        public static IDropActionProvider GetDropActionProvider()
        {
            return _container.Resolve<IDropActionProvider>();

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
            var configFile = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName + @"\logging.config.xml";
            var fi = new FileInfo(configFile);
            log4net.Config.XmlConfigurator.Configure(fi);

            Logger.Setup(DTE);

            LogManager.GetLogger(typeof(Application)).Debug("Logging Started");

        }

        public static void ResetSettings()
        {
            Settings = new VSDropSettings();
            SettingsHelper.SaveToStorage(Settings);

        }
    }
    public static class Logger
    {
        
        private static IAppender getAppender(Lazy<DTE> dteFetch)
        {
        
                var logger = new VisualStudioOutputLogger();
                VisualStudioOutputLogger.DTE = dteFetch;
            

            return logger;

        }
        public static void Setup(Lazy<DTE> dteFetch)
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            
            MemoryAppender memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);
            var appender = getAppender(dteFetch);
            if (hierarchy.Root.GetAppender(appender.Name) == null)
            {
                hierarchy.Root.AddAppender(appender);
            }
            hierarchy.Root.Level = Level.Debug;

            var settings = SettingsHelper.LoadSettingsFromStorage();
            if (settings != null) {
                if(settings.LogErrors) hierarchy.Root.Level = Level.All;
            }
            
            hierarchy.Configured = true;
        }
    }
}