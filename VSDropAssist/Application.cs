﻿using System;
using System.IO;
using Autofac;
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
            
            XmlConfigurator.Configure();
            LogManager.GetLogger(typeof(Application)).Debug("Logging Started");

        }

        public static void ResetSettings()
        {
            Settings = new VSDropSettings();
            SettingsHelper.SaveToStorage(Settings);

        }
    }
}