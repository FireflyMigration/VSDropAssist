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

namespace VSDropAssist
{
    [Export(typeof (IDropHandlerProvider))]
    [DropFormat("CF_VSSTGPROJECTITEMS")]
    [DropFormat("Microsoft.VisualStudio.GraphModel.Graph")]
    [Name("ClassMemberDropHandler")]
    [Order(Before = "DefaultFileDropHandler")]
    internal class GraphModelDropHandlerProvider : IDropHandlerProvider
    {
        private IServiceContainer _serviceContainer;

        static GraphModelDropHandlerProvider()
        {   
            Application.Init();

        }


        public IDropHandler GetAssociatedDropHandler(IWpfTextView wpfTextView)
        {
            return Application.GetClassMemberDropHandler(wpfTextView);
        }

        public bool FireflyImagesEnabled { get; set; }
    }

}