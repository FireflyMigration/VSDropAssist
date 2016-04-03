using System;
using System.Collections.Generic;
using System.Linq;

namespace VSDropAssist.DropActions
{
    internal class ClassVarDropAction : ClassOnlyWithSelectDropAction
    {
        public ClassVarDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService
            , new DropActionConfiguration()
            {
                FormatExpression = "var %v% = new %f%();", Delimiter = "\n", SupportsMembers = false, 
                ShiftMustBeDown=true ,SelectFirstLineOnly=true, ControlMustBeDown=true   }
            )
        {
        }
        

    }
}