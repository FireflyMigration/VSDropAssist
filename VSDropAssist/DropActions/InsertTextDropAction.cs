using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist.DropActions
{
    internal class InsertTextDropAction : DropActionBase
    {
        
        public override DropActionResultEnum Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo)
        {
            textView.TextBuffer.Insert(dragDropInfo.VirtualBufferPosition.Position.Position, getTextToInsert(nodes));

            return DropActionResultEnum.None;
        }

        private string getTextToInsert(IEnumerable<Node> nodes)
        {
            return string.Join("\n", nodes.Select(x => x.Member));
            
        }
    }
}