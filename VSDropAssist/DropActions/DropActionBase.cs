using System.Collections.Generic;
using log4net;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using VSDropAssist.Core.Entities;
using VSDropAssist.Core;

namespace VSDropAssist.DropActions
{
    public abstract class DropActionBase : IDropAction
    {
        protected ILog _log;

        protected DropActionBase()
        {
            _log = LogManager.GetLogger(GetType());
        }

        public abstract IExecuteResult  Execute(IEnumerable<Node> nodes, Core.ITextView textView,
            IDragDropInfo dragDropInfo);

        public virtual int Match(IDropQuery qry)
        {
            return 1;
        }
    }
}