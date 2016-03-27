using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Autofac;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using VSDropAssist.DropActions;

namespace VSDropAssist.Tests
{
    [TestFixture]
    public class DropConfigurationTests
    {
        [Test]
        public void match_compares_classes()
        {
            var c = new DropActionConfiguration() { SupportsClasses = true };
            var qry = new DropQuery() { ContainsClasses = true };

            Assert.AreEqual(1, c.Match(qry));
            Assert.AreEqual(0, c.Match(new DropQuery()));
        }
        [Test]
        public void match_compares_members()
        {
            var c = new DropActionConfiguration() { SupportsMembers = true };
            var qry = new DropQuery() { ContainsMembers = true };

            Assert.AreEqual(1, c.Match(qry));
            Assert.AreEqual(0, c.Match(new DropQuery()));
        }
        [Test]
        public void match_compares_dropping_into_class()
        {
            var c = new DropActionConfiguration() { SupportsDroppingIntoClass = true };
            var qry = new DropQuery() { DroppingIntoClass=true  };

            Assert.AreEqual(1, c.Match(qry));

            c = new DropActionConfiguration() { SupportsDroppingIntoClass = false  };
            Assert.AreEqual(0, c.Match(new DropQuery()));
        }

        [Test]
        public void match_compares_alt()
        {
            var c = new DropActionConfiguration() { AltMustBeDown = true };
            var qry = new DropQuery() {AltDown = true};

            Assert.AreEqual(1, c.Match(qry ));
            Assert.AreEqual(0, c.Match(new DropQuery()));

        }
        [Test]
        public void match_compares_ctrl()
        {
            var c = new DropActionConfiguration() { ControlMustBeDown = true };
            var qry = new DropQuery() { ControlDown = true };

            Assert.AreEqual(1, c.Match(qry));
            Assert.AreEqual(0, c.Match(new DropQuery()));

        }

        [Test]
        public void match_compares_shift()
        {
            var c = new DropActionConfiguration() { ShiftMustBeDown = true };
            var qry = new DropQuery() { ShiftDown = true };

            Assert.AreEqual(1, c.Match(qry));
            Assert.AreEqual(0, c.Match(new DropQuery()));

        }

        [Test]
        public void match_compares_shift_and_alt()
        {
            var c = new DropActionConfiguration() { ShiftMustBeDown = true, AltMustBeDown=true  };
            var qry = new DropQuery() { ShiftDown = true, AltDown=true  };

            Assert.AreEqual(2, c.Match(qry));
            Assert.AreEqual(0, c.Match(new DropQuery()));

        }


        [Test]
        public void match_compares_shift_and_alt_and_ctl()
        {
            var c = new DropActionConfiguration() { ShiftMustBeDown = true, AltMustBeDown = true, ControlMustBeDown=true  };
            var qry = new DropQuery() { ShiftDown = true, AltDown = true, ControlDown=true  };

            Assert.AreEqual(3, c.Match(qry));
            Assert.AreEqual(0, c.Match(new DropQuery()));

        }

    }
    [TestFixture]
    public class DropActionProviderTests
    {
        [SetUp]
        public static void setup()
        {
            var configFile = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logging.config.xml"));
            Assert.IsTrue(configFile.Exists);
            log4net.Config.XmlConfigurator.Configure(configFile);
        }
        [Test]
        public void method_level_declaration_dropaction_if_dragging_classes_and_Dropping_into_class()
        {

            var svc = getService();
            var query = new DropQuery()
            {
                ShiftDown = true,
                ContainsClasses = true,
                ContainsMembers = false,
                DroppingIntoMethod = true ,
                DroppingIntoClass = true
            };

            var actual = svc.GetAction(query);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<ClassVarDropAction>(actual);
        }
        [Test]
        public void module_level_declaration_dropaction_if_dragging_classes_and_Dropping_into_class()
        {

            var svc = getService();
            var query = new DropQuery()
            {
                ShiftDown = true,
                ContainsClasses = true,
                ContainsMembers = false,
                DroppingIntoMethod = false,
                DroppingIntoClass = true
            };

            var actual = svc.GetAction(query);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<ClassModuleVariableDropAction>(actual);
        }


        [Test]
        public void commalist_dropaction_if_dragging_members_and_Dropping_into_method()
        {

            var svc = getService();
            var query = new DropQuery()
            {
                ShiftDown = false,
                ContainsClasses = false ,
                ContainsMembers = true ,
                DroppingIntoMethod = true,
                DroppingIntoClass = true
            };

            var actual = svc.GetAction(query);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<CommaDelimitedListDropAction>(actual);
        }


        [Test]
        public void addcolumns_dropaction_if_dragging_members_and_Dropping_into_method()
        {

            var svc = getService();
            var query = new DropQuery()
            {
                ShiftDown=true,
                ContainsClasses = true,
                ContainsMembers = true ,
                DroppingIntoMethod = true,
                DroppingIntoClass = true
            };

            var actual = svc.GetAction(query);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<ColumnsAddDropAction>(actual);
        }

        [Test]
        public void newclass_dropaction_if_dragging_class_and_Dropping_into_method()
        {

            var svc = getService();
            var query = new DropQuery()
            {
                AltDown = true,
                ContainsClasses = true,
                ContainsMembers = false,
                DroppingIntoMethod = true,
                DroppingIntoClass = true
            };

            var actual = svc.GetAction(query);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<NewClassInstanceDropAction>(actual);
        }
        [Test]
        public void update_dropaction_if_dragging_members_and_Dropping_into_method()
        {
            
            var svc = getService( );
            var query = new DropQuery()
            {
                AltDown = true,
                ContainsClasses = true ,
                ContainsMembers = true,
                DroppingIntoMethod = true,
                DroppingIntoClass = true
            };

            var actual = svc.GetAction(query);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<MemberUpdateDropAction>(actual);
        }

        

        private IDropActionProvider getService(IFormatExpressionService formatExpressionService=null  )
        {
            if (formatExpressionService == null) formatExpressionService = new Mock<IFormatExpressionService>().Object;

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(DropActionProvider).Assembly)
           .AssignableTo<IConfigurableDropAction>().Except<ConfigurableDropAction>()
           .As<IConfigurableDropAction>();

            builder.RegisterInstance(formatExpressionService).As<IFormatExpressionService>();
            builder.RegisterType<DropActionProvider>().As<IDropActionProvider>();

            var ioc = builder.Build();

            return ioc.Resolve<IDropActionProvider>();
        }

     
    }
}