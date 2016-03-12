using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using VSDropAssist.DropInfoHandlers;

namespace VSDropAssist.Tests
{
    
    [TestFixture]
    public class CodeBuilderControllerTests
    {
        
        [Test]
        public void can_create_controller()
        {
            
        } 
    }

    [TestFixture ]
    public class TypeParserTests
    {
        [Test]
        public void can_handle_simple_text()
        {
            var typeText = "parent";
            var s = new TypeParser();

            var expected = "parent";
            var actual = s.GetTypeFromString(typeText);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void can_handle_grandparent()
        {
            var typeText = "(Name=Grandchild ParentType=(Name=Child ParentType=(Name=Parent ParentType=GrandParent))";
            var s = new TypeParser();

            var expected = "GrandParent.Parent.Child.Grandchild";
            var actual = s.GetTypeFromString(typeText);
            Assert.AreEqual(expected, actual );
        }
        [Test]
        public void can_handle_parent()
        {
            var typeText = "Name=Child ParentType=Parent)";
            var s = new TypeParser();

            var expected = "Parent.Child";
            var actual = s.GetTypeFromString(typeText);
            Assert.AreEqual(expected, actual);
        }
    }
  
    public class DropFormatTest
    {
        
    }
}
