using System;
using System.Collections.Generic;
using System.Linq;

namespace VSDropAssist.DropActions
{
    internal class ClassModuleVariableDropAction:ClassOnlyWithSelectDropAction
    {
        public ClassModuleVariableDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }

       

        protected override string GetFormatString()
        {
            return "public readonly %f% %v% = new %f%();\n";
        }
    }
}