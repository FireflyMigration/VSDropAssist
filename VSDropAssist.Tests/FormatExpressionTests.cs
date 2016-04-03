using NUnit.Framework;
using VSDropAssist.Core.Entities;
using VSDropAssist.DropActions;

namespace VSDropAssist.Tests
{
    [TestFixture]
    public class FormatExpressionTests
    {
        [Test]
        public void can_find_token_start_at_start_of_expr()
        {
            var expr = " %f%";
            var svc = new FormatExpressionService();
            var n = new Node()
            {
                Assembly="assembly", FullName="fullname", IsClass=true, Member="theMember", Namespace="theNamespace", NormalisedNamespace="normalisedNS",
                StartLine=1, Type="TheType", VariableName="theVariable"
            };
            var result = svc.GetTokenStart(n,expr, "%f%");
            Assert.AreEqual(1, result);
        }

        [Test]
        public void returns_neg1_if_token_not_found()
        {
            var expr = "%f%";
            var svc = new FormatExpressionService();
            var n = new Node()
            {
                Assembly = "assembly",
                FullName = "fullname",
                IsClass = true,
                Member = "theMember",
                Namespace = "theNamespace",
                NormalisedNamespace = "normalisedNS",
                StartLine = 1,
                Type = "TheType",
                VariableName = "theVariable"
            };
            var result = svc.GetTokenStart(n, expr, "%dummytoken%");
            Assert.AreEqual(-1, result);
        }
        [Test]
        public void can_find_token_start_inmiddle_of_expr()
        {
            var expr = "this is a %f% bit of token";
            var svc = new FormatExpressionService();
            var n = new Node()
            {
                Assembly = "assembly",
                FullName = "fullname",
                IsClass = true,
                Member = "theMember",
                Namespace = "theNamespace",
                NormalisedNamespace = "normalisedNS",
                StartLine = 1,
                Type = "TheType",
                VariableName = "theVariable"
            };
            var result = svc.GetTokenStart(n, expr, "%f%");
            Assert.AreEqual(10, result);
        }
    }
}