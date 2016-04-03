using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using VSDropAssist.Core;

namespace VSDropAssist.VisualStudio
{
    public class VSTextView : Core.ITextView
    {
        private readonly IWpfTextView _textView;

        public  VSTextView(IWpfTextView textView)
        {
            _textView = textView;
        }

        public IEdit CreateEdit()
        {
            var ep = _textView.TextBuffer.CreateEdit();

            return new VSEdit(ep);
        }

        public int GetIndentSize()
        {
            return _textView.Options.GetOptionValue<int>("Tabs/IndentSize");
        }

        public ILine GetLineFromLineNumber(int lineNumber)
        {
            var line = _textView.TextSnapshot.GetLineFromLineNumber(lineNumber);
            return new VSLine(line);
        }

        public ILine GetLineFromPosition(int droppedPosition)
        {
            var line = _textView.TextSnapshot.GetLineFromPosition(droppedPosition);
            return new VSLine(line);
        }

        public void MoveCaretToEndOfSelection()
        {
            _textView.Caret.MoveTo(_textView.Selection.End);
        }

        public object Object { get { return _textView; } }

        public void SelectBox(ILine startLine, int startPos, ILine endLine, int endPos)
        {
            
            var start = new VirtualSnapshotPoint((Microsoft.VisualStudio.Text.ITextSnapshotLine)startLine.RealObject , startPos );
            
            var end = new VirtualSnapshotPoint((Microsoft.VisualStudio.Text.ITextSnapshotLine)endLine.RealObject , endPos );
            
            _textView.Selection.Mode = TextSelectionMode.Box;
            _textView.Selection.Select(start, end);
        }
    }
}