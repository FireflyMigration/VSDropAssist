using System.Collections.Generic;
using System.Text;
using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    internal class MemberUpdateDropAction : ConfigurableDropAction
    {

        public MemberUpdateDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService
            , new DropActionConfiguration()
            {
                
                FormatExpression = "%v%.%m%.Value = ;",
                SupportsClasses = false,
                SupportsMembers = true,
                ControlMustBeDown = false,
                AltMustBeDown = true,
                ShiftMustBeDown = false,
                SupportsDroppingIntoClass = false,
                SupportsDroppingIntoMethod = true,
                SelectFirstLineOnly = false
            })
        {
        }
    }

}