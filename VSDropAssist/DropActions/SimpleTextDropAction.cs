using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist.DropActions
{
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
        public override IExecuteResult Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo, string indentText)
        {
            var filteredNodes = nodes.Where(x => getNodeFilter(x));

            //textView.TextBuffer.Insert(dragDropInfo.VirtualBufferPosition.Position.Position, String.Format("{0}\n", indentText));
            // move down a line
            var line = dragDropInfo.VirtualBufferPosition.Position.GetContainingLine();
            var nextline = line;
                //dragDropInfo.VirtualBufferPosition.Position.Snapshot.GetLineFromLineNumber(line.LineNumber + 1);
          
            
          
            var dropLine = nextline;
            var textLines = getTextToInsert(filteredNodes, "");
            foreach (var t in textLines)
            {
                var tmpIndentSpaces = Application.SmartIndentationService.GetDesiredIndentation(textView, dropLine);
                var tmpIndent = new string(' ', tmpIndentSpaces.HasValue ? tmpIndentSpaces.Value - 1 : indentText.Length);
                Debug.WriteLine("Indent {0}", tmpIndent.Length);
                
                textView.TextBuffer.Insert(dropLine.Start, string.Format("{0}{1}", tmpIndent, t));
                // refresh the line
                var insertedLine = dropLine.Start.GetContainingLine();
                
                textView.FormattedLineSource.FormatLineInVisualBuffer(insertedLine );
   dropLine =
                    dragDropInfo.VirtualBufferPosition.Position.Snapshot.GetLineFromLineNumber(dropLine.LineNumber + 1);

            }

            return new ExecuteResult(getSelectAfterDrop(),getSelectionWidth(filteredNodes),getSelectionHeight(filteredNodes), DropActionResultEnum.AllowCopy, getSelectionStart() + indentText.Length  );
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

        protected virtual IEnumerable<string> getTextToInsert(IEnumerable<Node> nodes, string indentText)
        {

            return nodes.Select(x => _formatExpressionService.ReplaceText( x, GetFormatString(), indentText));

        }
    }
}