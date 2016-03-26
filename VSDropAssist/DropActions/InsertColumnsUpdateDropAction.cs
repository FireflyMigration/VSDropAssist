using System.Collections.Generic;
using System.Text;

namespace VSDropAssist.DropActions
{
    internal class InsertColumnsUpdateDropAction : ConfigurableDropAction
    {
        
        public InsertColumnsUpdateDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService
            , new DropActionConfiguration() { AltMustBeDown=true, FormatExpression = "%v%.%m%.Value = ;" , SupportsClasses = false })
        {
        }
    }
    
}