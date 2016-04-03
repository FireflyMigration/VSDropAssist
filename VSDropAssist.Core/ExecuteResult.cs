namespace VSDropAssist.Core
{
    public class ExecuteResult : IExecuteResult 
    {
        public static IExecuteResult Copy
        {
            get
            {
                return new ExecuteResult(false,0,0, DropActionResultEnum.AllowCopy);
            }
        }

        public static IExecuteResult None
        {
            get
            {
                return new ExecuteResult(false,0,0, DropActionResultEnum.None);
            }
        }

        public ExecuteResult(bool selectAfterDrop, int selectionWidthInChars, int selectionHeightInLines, DropActionResultEnum dropActionResultEnum, int selectionStartInChars, int selectionStartLine)
            : this(selectAfterDrop, selectionWidthInChars, selectionHeightInLines, dropActionResultEnum )
        {
            SelectionStartInChars = selectionStartInChars;
            SelectionStartLine = selectionStartLine;
        }

        public ExecuteResult(bool selectAfterDrop, int selectionWidthInChars, int selectionHeightInLines, DropActionResultEnum dropActionResultEnum)
        {
            SelectAfterDrop = selectAfterDrop;
            SelectionWidthInChars = selectionWidthInChars;
            SelectionHeightInLines = selectionHeightInLines;
            DropActionResultEnum = dropActionResultEnum;
        }
        public bool SelectAfterDrop { get; set; }
        public int SelectionWidthInChars { get; set; }
        public int SelectionHeightInLines { get; set; }
        public DropActionResultEnum DropActionResultEnum { get; set; }
        public int SelectionStartInChars { get; set; }
        public int SelectionStartLine { get; set; }
    }
}