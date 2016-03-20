using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist.DropActions
{
    public static class StringExtensions
    {
        public static int IndexOf<TSource>(this IEnumerable<TSource> source,
    Func<TSource, bool> predicate)
        {
            int i = 0;

            foreach (TSource element in source)
            {
                if (predicate(element))
                    return i;

                i++;
            }

            return -1;
        }
    }
    internal abstract class SimpleTextDropAction : DropActionBase
    {
        protected readonly IFormatExpressionService _formatExpressionService;
        protected abstract string GetFormatString();

        protected SimpleTextDropAction(IFormatExpressionService formatExpressionService)
        {
            _formatExpressionService = formatExpressionService;
        }

        public virtual bool getNodeFilter(Node n)
        {
            return  true ;

        }

        private class SelectionDimensions
        {
            public int StartChar { get; set; }
            public int StartLine { get; set; }
            public int Length { get; set; }
        }
        public override IExecuteResult Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo)
        {
            var filteredNodes = nodes.Where(x => getNodeFilter(x));

       
            var dropLine = dragDropInfo.VirtualBufferPosition.Position.GetContainingLine();
            var lineBreak = dropLine.GetLineBreakText();
            var indent = Application.SmartIndentationService.GetDesiredIndentation(textView, dropLine );
            if (indent == null || !indent.HasValue)
            {
                // calc indent from dropped line
                var lineText = dropLine.GetText();

                var firstNonWhitespace = lineText.IndexOf(c => !char.IsWhiteSpace(c));
                indent = firstNonWhitespace;
            }

            List<CodeLine> codeLines = null;

            codeLines = getTextToInsert(filteredNodes).ToList();
            var indentText = "";
            if (indent.HasValue) indentText = new string(' ', indent.Value);

            foreach (var cl in codeLines)
            {
                cl.FormatExpression = string.Format("{0}{1}", indentText, cl.FormatExpression);
                cl.FormattedCode = string.Format("{0}{1}", indentText, cl.FormattedCode);

                cl.VariableStartPosition = cl.GetVariableStartPosition(_formatExpressionService);
                if (cl.VariableStartPosition > 0)
                {
                    Debug.WriteLine("{0} variable starts at {1}\n{2}^", cl.FormattedCode, cl.VariableStartPosition,
                        new string(' ', cl.VariableStartPosition));
                }
            }

            try
            {
                var edit = textView.TextBuffer.CreateEdit();

                
                var allText = string.Join("", codeLines.Select(x => x.FormattedCode));
                edit.Insert(dragDropInfo.VirtualBufferPosition.Position.GetContainingLine().End, lineBreak  + allText);
                edit.Apply();
            }
            catch (Exception e)
            {
                _log.Error("Error starting edit", e );
            }

            var selectAfterDrop = getSelectAfterDrop();
            var selectionWidthInChars = getSelectionWidth(codeLines );
            var selectionHeightInLines = getSelectionHeight(codeLines);
            var selectionStartInChars = getSelectionStart(codeLines);
            var selectionStartRow = dropLine.LineNumber + 1;
            return new ExecuteResult(selectAfterDrop,selectionWidthInChars,selectionHeightInLines, DropActionResultEnum.AllowCopy, selectionStartInChars , selectionStartRow );
        }

        protected virtual bool getSelectAfterDrop()
        {
            return true;
        }

        protected  virtual int getSelectionHeight(IEnumerable<CodeLine > lines)
        {
            return lines.Count();
        }

        protected virtual int getSelectionWidth(IEnumerable<CodeLine> lines)
        {
            return lines.Max(x => x.SourceNode.VariableName.Length);

        }
        protected virtual int getSelectionStart(IEnumerable<CodeLine> lines)
        {
            if (lines == null || !lines.Any()) return -1;
            return lines.FirstOrDefault().VariableStartPosition;
        }

        protected virtual IEnumerable<CodeLine> getTextToInsert(IEnumerable<Node> nodes)
        {

           return nodes.Select(x => new CodeLine() {
                FormattedCode=_formatExpressionService.ReplaceText(x, GetFormatString()),
                FormatExpression = GetFormatString(),
        
                SourceNode = x});
                
        }
        
    }

    public class CodeLine
    {
        public string FormatExpression { get; set; }
        public string FormattedCode { get; set; }
        public Node SourceNode { get; set; }
        public int VariableStartPosition { get; set; }

        public int GetVariableStartPosition(IFormatExpressionService formatExpressionService)
        {
            var g = Guid.NewGuid();
            var tmpFmt = FormatExpression.Replace("%v%", g.ToString());

            var tmpResult = formatExpressionService.ReplaceText(this.SourceNode, tmpFmt);
            return tmpResult.IndexOf(g.ToString());

        }
    }

}