using System.Collections.Generic;
using System.Linq;
using VSDropAssist.Core;
using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    internal class CommaDelimitedListDropAction : ConfigurableDropAction
    {


        public CommaDelimitedListDropAction(IFormatExpressionService formatExpressionService, IIndentationService indentationService) : base(formatExpressionService
            , new DropActionConfiguration() { FormatExpression = "%v%.%m%,", Delimiter="\n", SupportsClasses = false,
                SupportsDroppingIntoClass = false, SelectFirstLineOnly = false 
            }, indentationService )
        {
        }

    }
}