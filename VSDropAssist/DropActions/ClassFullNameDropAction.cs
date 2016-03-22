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

        protected override IEnumerable<CodeLine> getTextToInsert(IEnumerable<Node> nodes)
        {
            var ret = base.getTextToInsert(nodes).ToList();

            // trim trailing newline
            var last = ret.Last();
            var code = last.FormattedCode;
            last.FormattedCode = code.Substring(0, code.Length - 1);

            return ret;
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
        protected override IEnumerable<CodeLine> getTextToInsert(IEnumerable<Node> nodes)
        {
            var ret = base.getTextToInsert(nodes).ToList();

            // trim trailing newline
            var last = ret.Last();
            var code = last.FormattedCode;
            last.FormattedCode = code.Substring(0, code.Length - 1);

            return ret;
        }
    }
}