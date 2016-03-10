using System;
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

        public virtual bool getNodeFilter(Node n)
        {
            return  true ;

        }
        public override IExecuteResult Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo, string indentText)
        {
            var filteredNodes = nodes.Where(x => getNodeFilter(x));

          
            textView.TextBuffer.Insert(dragDropInfo.VirtualBufferPosition.Position.Position, getTextToInsert(filteredNodes, indentText ));


            return new ExecuteResult(getSelectAfterDrop(),getSelectionWidth(filteredNodes),getSelectionHeight(filteredNodes), DropActionResultEnum.AllowCopy, getSelectionStart() );
        }

        protected virtual bool getSelectAfterDrop()
        {
            return true;
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
            return Math.Max(0, GetFormatString().IndexOf("%v%"));
        }

        protected virtual string getTextToInsert(IEnumerable<Node> nodes, string indentText)
        {

            return _formatExpressionService.ReplaceText(string.Empty, nodes, GetFormatString(), indentText);

        }
    }
}