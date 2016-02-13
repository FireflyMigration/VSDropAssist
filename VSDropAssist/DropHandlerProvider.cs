using System.ComponentModel.Composition;
using System.Text;
using System.Threading.Tasks;
using Autofac.Core;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using Microsoft.VisualStudio.Utilities;

namespace VSDropAssist
{
    [Export(typeof(IDropHandlerProvider))]
    [DropFormat("Microsoft.VisualStudio.GraphModel.Graph")]
    [Name("TestDropHandler")]
    [Order(Before = "DefaultFileDropHandler")]
    internal class DropHandlerProvider : IDropHandlerProvider
    {
        static DropHandlerProvider()
        {

          Application.Init();
        }
        public IDropHandler GetAssociatedDropHandler(IWpfTextView wpfTextView)
        {
            return Application.GetDropHandler(wpfTextView);
        }
    }
}
