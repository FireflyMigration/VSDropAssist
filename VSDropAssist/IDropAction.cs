using System.Collections.Generic;
using Microsoft.VisualStudio.Text.Editor;

namespace VSDropAssist
{
    internal interface IDropAction
    {
        DropActionResultEnum Execute(IEnumerable<Node> nodes, IWpfTextView textView);
    }
}