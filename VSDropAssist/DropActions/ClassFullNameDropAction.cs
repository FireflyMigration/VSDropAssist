using System;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    internal  class ClassFullNameDropAction : ConfigurableDropAction
    {
        
        public ClassFullNameDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService,
             new DropActionConfiguration() { FormatExpression = "%f%",
                 Delimiter = "\n",
                 TokenToSelectAfterDrop ="%f%" ,
                 SupportsMembers = false })
        {
        }
       
    }
}