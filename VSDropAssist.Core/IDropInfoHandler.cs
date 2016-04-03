using System.Collections.Generic;
using VSDropAssist.Core.Entities;

namespace VSDropAssist.Core
{
    public interface IDropInfoHandler
    {
        bool CanUnderstand(IDragDropInfo dragDropInfo);

        IEnumerable<Node> GetNodes(IDragDropInfo dragDropInfo);
    }
}