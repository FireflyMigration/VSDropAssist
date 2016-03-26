using System.Collections.Generic;
using System.Linq;

namespace VSDropAssist.DropActions
{
    internal class CommaDelimitedListDropAction : ConfigurableDropAction
    {


        public CommaDelimitedListDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService
            , new DropActionConfiguration() { FormatExpression = "%v%.%m%,", Delimiter="\n", SupportsClasses = false,
                SupportsDroppingIntoClass = false,
            })
        {
        }

    }
}