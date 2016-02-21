using System.IO;
using Autofac;
using log4net.Config;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using VSDropAssist.DropActions;
using VSDropAssist.DropInfoHandlers;

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
        }

        private static void initIoC()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<InsertColumnsAddDropAction>().As<IDropAction>();
            builder.RegisterType<GraphModelDropInfoHandler>().As<IDropInfoHandler>();
            builder.RegisterType<DropHandler>().As<IDropHandler>();

            _container = builder.Build();
        }

        public static IDropHandler GetClassMemberDropHandler(IWpfTextView textView)

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
            var fi = new FileInfo("logging.config.xml");
            if (!fi.Exists) throw new FileNotFoundException("logging.config");

            XmlConfigurator.ConfigureAndWatch(fi);
        }
    }
}