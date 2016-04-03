using System.Collections.Generic;

using VSDropAssist.Core.Entities;

namespace VSDropAssist.Core
{
    public interface IDropAction
    {
        IExecuteResult Execute(IEnumerable<Node> nodes, ITextView textView, IDragDropInfo dragDropInfo);
        int Match(IDropQuery qry);
    }

    
}