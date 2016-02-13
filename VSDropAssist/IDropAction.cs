using System.Collections.Generic;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist
{
    internal interface IDropAction
    {
        DropActionResultEnum Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo);
    }
}