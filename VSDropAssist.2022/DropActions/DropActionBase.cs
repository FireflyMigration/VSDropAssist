using System.Collections.Generic;
using log4net;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using VSDropAssist.Entities;

namespace VSDropAssist.DropActions
{
    public abstract class DropActionBase : IDropAction
    {
        protected ILog _log;

        protected DropActionBase()
        {
            _log = LogManager.GetLogger(GetType());
        }

        public abstract IExecuteResult  Execute(IEnumerable<Node> nodes, IWpfTextView textView,
            DragDropInfo dragDropInfo);

        public virtual int Match(DropQuery qry)
        {
            return 1;
        }
    }
}