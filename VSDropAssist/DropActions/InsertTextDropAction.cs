using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using VSDropAssist.Core;
using VSDropAssist.Forms;

namespace VSDropAssist.DropActions
{

    internal class DialogDropAction : DropActionBase
    {
        private readonly IControllerFactory _controllerFactory;

        public DialogDropAction(IControllerFactory controllerFactory )
        {
            _controllerFactory = controllerFactory;
        }
        
        public override DropActionResultEnum Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo)
        {
            throw new NotImplementedException();
        }
    }
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