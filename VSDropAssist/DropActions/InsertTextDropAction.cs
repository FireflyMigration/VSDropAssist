using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist.DropActions
{
    internal class InsertTextDropAction : DropActionBase
    {
        
        public override DropActionResultEnum Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo)
        {
            textView.TextBuffer.Insert(dragDropInfo.VirtualBufferPosition.Position.Position, "Demo text");

            return DropActionResultEnum.None;
        }
    }
}