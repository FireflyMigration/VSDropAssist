using System.Net.Mime;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using VSDropAssist.Core;
using ITextView = VSDropAssist.Core.ITextView;

namespace VSDropAssist.VisualStudio
{
    public class VSIndentationService : IIndentationService
    {
        private readonly ISmartIndentationService _smartIndentationService;

        public VSIndentationService(ISmartIndentationService smartIndentationService)
        {
            _smartIndentationService = smartIndentationService;
        }

        public int? GetDesiredIndentation(ITextView textView, ILine dropLine)
        {
            var indent = _smartIndentationService.GetDesiredIndentation((Microsoft.VisualStudio.Text.Editor.ITextView)textView.Object, (Microsoft.VisualStudio.Text.ITextSnapshotLine)dropLine.RealObject);

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

            return indent;

        }
    }
    public class VSLine : ILine
    {
        private ITextSnapshotLine _textSnapshotLine;
        

        public  VSLine(ITextSnapshotLine textSnapshotLine)
        {
            _textSnapshotLine = textSnapshotLine;
        }

        public int LineNumber
        {
            get
            {
                return _textSnapshotLine.LineNumber;
            }
        }

        public string GetLineBreakText()
        {
            return _textSnapshotLine.GetLineBreakText();
        }

        public string GetText()
        {
            return _textSnapshotLine.GetText();
        }

        public object RealObject
        {
            get { return _textSnapshotLine; }
        }
    }
}