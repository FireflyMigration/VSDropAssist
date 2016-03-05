using System.Collections.Generic;
using System.Linq;

namespace VSDropAssist.DropActions
{
    internal class CommaDelimitedListDropAction : SimpleTextDropAction
    {

        private const string FORMAT = "%v%.%m%,\n";
        protected override string GetFormatString()
        {
            return FORMAT;
        }

        public CommaDelimitedListDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }
    }
}