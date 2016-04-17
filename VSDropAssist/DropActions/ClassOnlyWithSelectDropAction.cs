using VSDropAssist.Core;
using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    internal abstract class ClassOnlyWithSelectDropAction : ConfigurableDropAction
    {
     
        protected  ClassOnlyWithSelectDropAction(IFormatExpressionService formatExpressionService, IDropActionConfiguration config, IIndentationService indentationService ) : base(formatExpressionService,config , indentationService )
        {
        }
    }
}