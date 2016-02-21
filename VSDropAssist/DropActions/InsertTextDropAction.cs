using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist.DropActions
{
    internal class InsertTextDropAction : DropActionBase
    {
        public override DropActionResultEnum Execute(IEnumerable<Node> nodes, IWpfTextView textView,
            DragDropInfo dragDropInfo)
        {
            textView.TextBuffer.Insert(dragDropInfo.VirtualBufferPosition.Position.Position, getTextToInsert(nodes));
            
            return DropActionResultEnum.None;
        }

        private string getTextToInsert(IEnumerable<Node> nodes)
        {
            var output = new StringBuilder();
            
            
            foreach (var n in nodes)
            {
                output.AppendFormat("Columns.Add({0}.{1})\n;",n.Type.ToLower(), n.Member);
            }

            return output.ToString();
        }
    }
}