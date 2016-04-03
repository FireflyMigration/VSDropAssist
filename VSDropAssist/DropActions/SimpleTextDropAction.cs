using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VSDropAssist.Core;
using VSDropAssist.Core.Entities;

namespace VSDropAssist.DropActions
{
    public abstract class SimpleTextDropAction : DropActionBase
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

       
        public override IExecuteResult Execute(IEnumerable<Node> nodes, Core.ITextView textView, IDragDropInfo dragDropInfo)
        {
            var filteredNodes = nodes.Where(x => getNodeFilter(x));


            var dropLine = dragDropInfo.GetDroppingLine();
            var lineBreak = dropLine.GetLineBreakText();
            var indent = Application.SmartIndentationService.GetDesiredIndentation((Microsoft.VisualStudio.Text.Editor.ITextView)textView.Object, (Microsoft.VisualStudio.Text.ITextSnapshotLine)dropLine.RealObject);
            if (indent == null || !indent.HasValue)
            {
                // calc indent from dropped line
                var lineText = dropLine.GetText();

                var firstNonWhitespace = lineText.IndexOf(c => !char.IsWhiteSpace(c));
                indent = firstNonWhitespace;

                // indent if char is a {
                if (lineText[firstNonWhitespace] == '{')
                {
                    var indentSize = textView.GetIndentSize();
                    indent += indentSize;
                }
            }

            List<CodeLine> codeLines = null;

            codeLines = getTextToInsert(filteredNodes).Distinct().ToList();
            var indentText = "";
            if (indent.HasValue) indentText = new string(' ', indent.Value);

            foreach (var cl in codeLines)
            {
                cl.FormatExpression = string.Format("{0}{1}", indentText, cl.FormatExpression);
                cl.FormattedCode = string.Format("{0}{1}", indentText, cl.FormattedCode);

                
                if (cl.TokenStartPosition  >= 0)
                {
                    cl.TokenStartPosition += indent.Value; // offset the token start, as we've indented the code

                    Debug.WriteLine("{0} variable starts at {1}\n{2}^", cl.FormattedCode, cl.TokenStartPosition,
                        new string(' ', cl.TokenStartPosition));
                }
            }

            try
            {
                var edit = textView.CreateEdit();
                
                var allText = string.Join(getDelimiter(), codeLines.Select(x => x.FormattedCode));
                edit.Insert(dragDropInfo.GetStartPosition(), lineBreak  + allText);
                
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

        protected virtual string getDelimiter()
        {
            return "";
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
            if (lines==null || !lines.Any()) return 0;
            return lines.Max(x => x.TokenLength);

        }
        protected virtual int getSelectionStart(IEnumerable<CodeLine> lines)
        {
            if (lines == null || !lines.Any()) return -1;
            return lines.FirstOrDefault().TokenStartPosition ;
        }

        protected virtual string getTokenToSelectAfterDrop()
        {
            return "%v%";
        }
        protected virtual IEnumerable<CodeLine> getTextToInsert(IEnumerable<Node> nodes)
        {

           return nodes.Select(node => new CodeLine() {
                FormattedCode=_formatExpressionService.ReplaceText(node, GetFormatString()),
                FormatExpression = GetFormatString(),
        TokenStartPosition = _formatExpressionService.GetTokenStart(node, GetFormatString(), getTokenToSelectAfterDrop()),
        TokenLength = _formatExpressionService.GetTokenLength(node, getTokenToSelectAfterDrop()),
                SourceNode = node});
                
        }
        
    }
}