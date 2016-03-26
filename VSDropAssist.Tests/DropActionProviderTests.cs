using Moq;
using NUnit.Framework;
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
        [Test]
        public void can_locate_dropaction_shift()
        {
            var formatExpressionService = new Mock<IFormatExpressionService>();
            var s = new ConfigurableDropAction(formatExpressionService.Object , new DropActionConfiguration() { ShiftMustBeDown=true });
            var c = new ConfigurableDropAction(formatExpressionService.Object, new DropActionConfiguration() { ControlMustBeDown = true });
            var actions = new[]
            {
                s, c
            };
            IDropActionProvider svc = new DropActionProvider(actions) ;
            var qry = new DropQuery() { ShiftDown = true };

            var result = svc.GetAction(qry);
            Assert.IsNotNull(result);
            Assert.AreSame(s, result );

        }
        [Test]
        public void can_locate_dropaction_control()
        {
            var formatExpressionService = new Mock<IFormatExpressionService>();
            var s = new ConfigurableDropAction(formatExpressionService.Object, new DropActionConfiguration() { ShiftMustBeDown = true });
            var c = new ConfigurableDropAction(formatExpressionService.Object, new DropActionConfiguration() { ControlMustBeDown = true });
            var actions = new[]
            {
                s, c
            };
            IDropActionProvider svc = new DropActionProvider(actions);
            var qry = new DropQuery() { ControlDown = true };

            var result = svc.GetAction(qry);
            Assert.IsNotNull(result);
            Assert.AreSame(c, result);

        }
    }
}