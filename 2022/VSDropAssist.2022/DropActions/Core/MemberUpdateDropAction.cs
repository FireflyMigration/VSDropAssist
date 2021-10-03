using System.Collections.Generic;
using System.Text;
using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    public class MemberUpdateDropAction : ConfigurableDropAction
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
            },
            "Column Update",
            "Adds a column.value=XX for every dropped column")
        {
        }
    }

}