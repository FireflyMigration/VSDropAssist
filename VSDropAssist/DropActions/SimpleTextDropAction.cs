using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist.DropActions
{
    internal abstract class SimpleTextDropAction : DropActionBase
    {
        protected readonly IFormatExpressionService _formatExpressionService;
        protected abstract string GetFormatString();

        protected SimpleTextDropAction(IFormatExpressionService formatExpressionService)
        {
            _formatExpressionService = formatExpressionService;
        }

        public override IExecuteResult Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo, string indentText)
        {
            textView.TextBuffer.Insert(dragDropInfo.VirtualBufferPosition.Position.Position, getTextToInsert(nodes, indentText ));


            return new ExecuteResult(true,getSelectionWidth(nodes),getSelectionHeight(nodes), DropActionResultEnum.AllowCopy, getSelectionStart() );
        }

        protected  virtual int getSelectionHeight(IEnumerable<Node> nodes)
        {
            return nodes.Count();
        }

        protected virtual int getSelectionWidth(IEnumerable<Node> nodes  )
        {
            return nodes.Max(x => x.Type.Length);

        }
        protected virtual int getSelectionStart()
        {
            return GetFormatString().IndexOf("%v%");
        }

        protected virtual string getTextToInsert(IEnumerable<Node> nodes, string indentText)
        {

            return _formatExpressionService.ReplaceText(string.Empty, nodes, GetFormatString(), indentText);

        }
    }
}