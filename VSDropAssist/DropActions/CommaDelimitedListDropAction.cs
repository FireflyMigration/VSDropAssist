using System.Collections.Generic;
using System.Linq;

namespace VSDropAssist.DropActions
{
    internal class CommaDelimitedListDropAction : ClassMemberDropAction
    {

        private const string FORMAT = "%v%.%m%,\n";
        protected override string GetFormatString()
        {
            return FORMAT;
        }

        public CommaDelimitedListDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }

        protected override IEnumerable<CodeLine> getTextToInsert(IEnumerable<Node> nodes)
        {
            // trim trailing comma
            var ret= base.getTextToInsert(nodes).ToList();

            var lastItem = ret.Last();
            var code = lastItem.FormattedCode;
            if (code.EndsWith(",\n"))
            {
                lastItem.FormattedCode = code.Substring(0, code.Length - 2) + "\n";
            }
            return ret;
        }
    }
}