using System.Collections.Generic;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist.DropActions
{
    internal abstract class SimpleTextDropAction : DropActionBase
    {
        public override DropActionResultEnum Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo)
        {
            textView.TextBuffer.Insert(dragDropInfo.VirtualBufferPosition.Position.Position, getTextToInsert(nodes));

            return DropActionResultEnum.None;
        }

        protected abstract string getTextToInsert(IEnumerable<Node> nodes);
    }
}