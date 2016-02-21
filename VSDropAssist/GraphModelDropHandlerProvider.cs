using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using Microsoft.VisualStudio.Utilities;

namespace VSDropAssist
{
    [Export(typeof (IDropHandlerProvider))]
    [DropFormat("Microsoft.VisualStudio.GraphModel.Graph")]
    [Name("ClassMemberDropHandler")]
    [Order(Before = "DefaultFileDropHandler")]
    internal class GraphModelDropHandlerProvider : IDropHandlerProvider
    {
        static GraphModelDropHandlerProvider()
        {
            Application.Init();
        }

        public IDropHandler GetAssociatedDropHandler(IWpfTextView wpfTextView)
        {
            return Application.GetClassMemberDropHandler(wpfTextView);
        }
    }

    [Export(typeof (IDropHandlerProvider))]
    [DropFormat("CF_VSSTGPROJECTITEMS")]
    [Name("ClassMemberDropHandler")]
    [Order(Before = "DefaultFileDropHandler")]
    internal class ProjectItemDropHandlerProvider : IDropHandlerProvider
    {
        static ProjectItemDropHandlerProvider()
        {
            Application.Init();
        }

        public IDropHandler GetAssociatedDropHandler(IWpfTextView wpfTextView)
        {
            return Application.GetClassMemberDropHandler(wpfTextView);
        }
    }
}