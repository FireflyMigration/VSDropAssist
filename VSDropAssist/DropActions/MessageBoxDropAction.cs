using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using System.ComponentModel;

using VSDropAssist.Core.Entities;
using VSDropAssist.Core;

namespace VSDropAssist.DropActions
{
    internal class MessageBoxDropAction : DropActionBase
    {
        public override IExecuteResult Execute(IEnumerable<Node> nodes, Core.ITextView textView,
            IDragDropInfo dragDropInfo)
        {
            var msg = string.Format("You dropped:\n{0}",
                string.Join("\n",
                    nodes.Select(x => string.Format("{0}.{1}.{2}.{3}", x.Assembly, x.Namespace, x.Type, x.Member))));
            _log.Debug(msg);
            MessageBox.Show(msg);

            return ExecuteResult.None;
        }
    }
}