using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using Microsoft.VisualStudio.Utilities;
using VSDropAssist.DropActions;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text.Operations;

namespace VSDropAssist
{
    [Export(typeof (IDropHandlerProvider))]
    [DropFormat("CF_VSSTGPROJECTITEMS")]
    [DropFormat("Microsoft.VisualStudio.GraphModel.Graph")]
    [Name("ClassMemberDropHandler")]
    [Order(Before = "DefaultFileDropHandler")]
    internal class DropHandlerProvider : IDropHandlerProvider
    {
        

        [Import]
        IEditorOperationsFactoryService factory = null;

        [Import ]
        ISmartIndentationService smartIndentationService = null;

        static DropHandlerProvider()
        {   
            Application.Init();
            
        }


        public IDropHandler GetAssociatedDropHandler(IWpfTextView wpfTextView)
        {
            Application.EditorOperationsFactoryService = factory;
            Application.SmartIndentationService = smartIndentationService;
            return Application.GetDropHandler(wpfTextView);
        }

        public bool FireflyImagesEnabled { get; set; }
    }

}