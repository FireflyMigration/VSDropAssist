using System;
using System.Collections.Generic;
using System.Linq;

namespace VSDropAssist.DropActions
{
    internal abstract class ClassOnlyWithSelectDropAction : ClassOnlyDropAction
    {
        protected override bool getSelectAfterDrop()
        {
            return true;
        }

        protected override int getSelectionHeight(IEnumerable<CodeLine> lines)
        {
            return Math.Min(1, lines.Count());
        }

        protected override int getSelectionWidth(IEnumerable<CodeLine> lines)
        {
            if (lines == null || !lines.Any()) return 0;

            return lines.First().SourceNode?.VariableName?.Length ?? 0;
        }

        protected override int getSelectionStart(IEnumerable<CodeLine> lines)
        {
            if (lines == null || !lines.Any()) return 0;
            return lines.First().VariableStartPosition;
        }

        

        public ClassOnlyWithSelectDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }
    }
    internal class ClassVarDropAction : ClassOnlyWithSelectDropAction
    {
        public ClassVarDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }

        protected override string GetFormatString()
        {
            return "var %v% = new %f%();\n";
        }

    }
}