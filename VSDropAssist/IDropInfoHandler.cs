using System.Collections.Generic;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist
{
    internal interface IDropInfoHandler
    {
        IEnumerable<Node> GetNodes(DragDropInfo dragDropInfo);
    }
}