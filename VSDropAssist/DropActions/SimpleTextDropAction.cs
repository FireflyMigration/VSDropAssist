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
            
            
            try
            {
                var edit = textView.TextBuffer.CreateEdit();
                var indentText = "";
                if (indent.HasValue) indentText = new string(' ', indent.Value);

                var textLines = getTextToInsert(filteredNodes);

                var indentedLines = textLines.Select(x => string.Format("{0}{1}", indentText, x));
                var allText = string.Join("", indentedLines);
                edit.Insert(dragDropInfo.VirtualBufferPosition.Position.GetContainingLine().End, lineBreak  + allText);
                edit.Apply();
            }
            catch (Exception e)
            {
                _log.Error("Error starting edit", e );
            }

            var selectAfterDrop = getSelectAfterDrop();
            var selectionWidthInChars = getSelectionWidth(filteredNodes);
            var selectionHeightInLines = getSelectionHeight(filteredNodes);
            var selectionStartInChars = getSelectionStart() + indent.GetValueOrDefault();
            var selectionStartRow = dropLine.LineNumber + 1;
            return new ExecuteResult(selectAfterDrop,selectionWidthInChars,selectionHeightInLines, DropActionResultEnum.AllowCopy, selectionStartInChars , selectionStartRow );
        }

        protected virtual bool getSelectAfterDrop()
        {
            return true;
        }

        protected  virtual int getSelectionHeight(IEnumerable<Node> nodes)
        {
            return nodes.Count();
        }

        protected virtual int getSelectionWidth(IEnumerable<Node> nodes  )
        {
            return nodes.Max(x => x.VariableName.Length);

        }
        protected virtual int getSelectionStart()
        {
            return Math.Max(0, GetFormatString().IndexOf("%v%"));
        }

        protected virtual IEnumerable<string> getTextToInsert(IEnumerable<Node> nodes)
        {

            return nodes.Select(x => _formatExpressionService.ReplaceText( x, GetFormatString()));

        }
    }
}