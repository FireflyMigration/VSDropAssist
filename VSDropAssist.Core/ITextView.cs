namespace VSDropAssist.Core
{
    public interface ITextView
    {
        int GetIndentSize();
        IEdit  CreateEdit();
        ILine GetLineFromPosition(int droppedPosition);
        ILine GetLineFromLineNumber(int lineNumber);
        void SelectBox(ILine startLine, int startPos, ILine endLine, int endPos);
        void MoveCaretToEndOfSelection();
        object Object { get; }
    }
}