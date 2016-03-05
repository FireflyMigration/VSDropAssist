using System.Collections.Generic;
using System.Text;

namespace VSDropAssist.DropActions
{
    internal class InsertColumnsUpdateDropAction : SimpleTextDropAction
    {

        private const string FORMAT = "%v%.%m%.Value = ;\n";
        protected override string GetFormatString()
        {
            return FORMAT;
        }


        public InsertColumnsUpdateDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }
    }
    
}