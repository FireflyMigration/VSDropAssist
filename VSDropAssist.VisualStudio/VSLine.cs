using Microsoft.VisualStudio.Text;
using VSDropAssist.Core;

namespace VSDropAssist.VisualStudio
{
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