using System.Collections.Generic;
using System.Linq;
using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    internal class CommaDelimitedListDropAction : ConfigurableDropAction
    {


        public CommaDelimitedListDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService
            , new DropActionConfiguration()
            {
                FormatExpression = "%v%.%m%,",
                Delimiter = "\n",
                SupportsClasses = false,
                SupportsMembers = true,
                ControlMustBeDown = false,
                AltMustBeDown = false,
                ShiftMustBeDown = false,
                SupportsDroppingIntoClass = false,
                SupportsDroppingIntoMethod = true,
                SelectFirstLineOnly = false
            })
        {
        }

    }
}