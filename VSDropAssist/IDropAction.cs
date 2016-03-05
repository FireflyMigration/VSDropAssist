using System.Collections.Generic;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using VSDropAssist;

namespace VSDropAssist
{
    public interface IExecuteResult
    {
        bool SelectAfterDrop { get; }
        int SelectionWidthInChars { get;  }
        int SelectionHeightInLines { get; }
        DropActionResultEnum DropActionResultEnum { get; set; }
        int SelectionStartInChars { get;  }
    }

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

        public ExecuteResult(bool selectAfterDrop, int selectionWidthInChars, int selectionHeightInLines, DropActionResultEnum dropActionResultEnum, int selectionStartInChars)
            : this(selectAfterDrop, selectionWidthInChars, selectionHeightInLines, dropActionResultEnum )
        {
            SelectionStartInChars = selectionStartInChars;
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
    }
    internal interface IDropAction
    {
        IExecuteResult Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo, string indentText);
    }
}