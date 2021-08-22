using System;
using System.Collections.Generic;
using System.Linq;
using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    public class ClassVarDropAction : ClassOnlyWithSelectDropAction
    {
        public ClassVarDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService
            , new DropActionConfiguration()
            {
                FormatExpression = "var %v% = new %f%();",
                Delimiter = "\n",
                SupportsMembers = true,
                SupportsClasses=true,
                ShiftMustBeDown = false,
                SelectFirstLineOnly = true,
                ControlMustBeDown = true,
                SupportsDroppingIntoMethod = true,
                SupportsDroppingIntoClass = false
            },
            "new variable",
            "Declares a new vriable for every dropped class/column"
            )
        {
        }


    }
}