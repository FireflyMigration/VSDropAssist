namespace VSDropAssist.Core
{
    public interface IExecuteResult
    {
        bool SelectAfterDrop { get; }
        int SelectionWidthInChars { get;  }
        int SelectionHeightInLines { get; }
        DropActionResultEnum DropActionResultEnum { get; set; }
        int SelectionStartInChars { get;  }

        int SelectionStartLine { get; }
    }
}