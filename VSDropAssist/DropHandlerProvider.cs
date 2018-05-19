using System.ComponentModel.Composition;

using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Utilities;

namespace VSDropAssist
{
    /// <summary>
    /// The class discovered by Visual Studio in order to register the drop handlers and is the main entry point for the application
    /// This class will handle drag and drop, of objectgraphs (ie multi-selection from solutionExplorer) and Individual solution explroer items, onto a C# editor
    /// </summary>
    [Export(typeof(IDropHandlerProvider))]
    [DropFormat("CF_VSSTGPROJECTITEMS")]
    [DropFormat("Microsoft.VisualStudio.GraphModel.Graph")]
    [Name("ClassMemberDropHandler")]
    [ContentType("csharp")]
    [Order(Before = "DefaultFileDropHandler")]
    internal class DropHandlerProvider : IDropHandlerProvider
    {
        [Import]
        private IEditorOperationsFactoryService factory = null;

        [Import]
        private ISmartIndentationService smartIndentationService = null;

        static DropHandlerProvider()
        {
            Application.Init();
        }

        /// <summary>
        /// Called by Visual Studio to get the class that will handle the drag=drop operation
        /// </summary>
        /// <param name="wpfTextView"></param>
        /// <returns></returns>
        public IDropHandler GetAssociatedDropHandler(IWpfTextView wpfTextView)
        {
            Application.EditorOperationsFactoryService = factory;
            Application.SmartIndentationService = smartIndentationService;
            return Application.GetDropHandler(wpfTextView);
        }

        public bool FireflyImagesEnabled { get; set; }
    }
}