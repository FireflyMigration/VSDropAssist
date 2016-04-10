using System;
using System.Collections.Generic;
using System.Linq;
using VSDropAssist.Core;
using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    internal class ClassModuleVariableDropAction:ClassOnlyWithSelectDropAction
    {
        public ClassModuleVariableDropAction(IFormatExpressionService formatExpressionService, IIndentationService indentationService) : base(formatExpressionService
            , new DropActionConfiguration() { FormatExpression= "public readonly %f% %v% = new %f%();" , SupportsMembers = false,ShiftMustBeDown=true  }, indentationService )
        {
        }

       
    }
}