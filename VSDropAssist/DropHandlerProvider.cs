using System.ComponentModel.Composition;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
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
            var fi = new FileInfo("logging.config.xml");
            if (!fi.Exists) throw new FileNotFoundException("logging.config");

            XmlConfigurator.ConfigureAndWatch(fi);
        }
        public IDropHandler GetAssociatedDropHandler(IWpfTextView wpfTextView)
        {
            return new DropHandler(wpfTextView);
        }
    }
}
