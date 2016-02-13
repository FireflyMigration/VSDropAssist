using System.Collections.Generic;
using log4net;
using Microsoft.VisualStudio.Text.Editor;

namespace VSDropAssist.DropActions
{
    internal abstract class DropActionBase : IDropAction
    {
        protected ILog _log = null;

        protected DropActionBase()
        {
            _log = LogManager.GetLogger(GetType());
        }

        public abstract DropActionResultEnum Execute(IEnumerable<Node> nodes, IWpfTextView textView);
    }
}