using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist.DropActions
{
    internal class NewClassInstanceDropAction : ClassOnlyDropAction
    {
        public NewClassInstanceDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }

        protected override string GetFormatString()
        {
            return "new %f%();\n";
        }
    }
    internal  class ClassFullNameDropAction : ClassOnlyDropAction
    {
        
        public ClassFullNameDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }
        protected override int getSelectionWidth(IEnumerable<CodeLine> lines)
        {
            return lines.Max(x => x.SourceNode.FullName).Length;
        }


        protected override string GetFormatString()
        {
            return  "%f%\n";
        }
    }
}