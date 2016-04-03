using System;
using System.Collections.Generic;
using System.Linq;
using VSDropAssist.Core;
using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    internal class ClassModuleVariableDropAction:ClassOnlyWithSelectDropAction
    {
        public ClassModuleVariableDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService
            , new DropActionConfiguration() { FormatExpression= "public readonly %f% %v% = new %f%();\n" , SupportsMembers = false,ShiftMustBeDown=true  })
        {
        }

       
    }
}