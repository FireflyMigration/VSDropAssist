using System.Collections.Generic;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist
{
    internal interface IDropInfoHandler
    {
        bool CanUnderstand(DragDropInfo dragDropInfo);

        IEnumerable<Node> GetNodes(DragDropInfo dragDropInfo);
    }
}