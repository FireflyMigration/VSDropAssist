using System.Collections.Generic;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using VSDropAssist.Entities;

namespace VSDropAssist
{
    public interface IDropInfoHandler
    {
        bool CanUnderstand(DragDropInfo dragDropInfo);

        IEnumerable<INode> GetNodes(DragDropInfo dragDropInfo);
    }
}