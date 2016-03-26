using System;
using System.Collections.Generic;
using System.Linq;

namespace VSDropAssist.DropActions
{
    internal class ClassModuleVariableDropAction:ClassOnlyWithSelectDropAction
    {
        public ClassModuleVariableDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService
            , new DropActionConfiguration() { FormatExpression= "public readonly %f% %v% = new %f%();\n" , SupportsMembers = false, SupportsDroppingIntoMethod=false , ShiftMustBeDown=true  })
        {
        }

       
    }
}