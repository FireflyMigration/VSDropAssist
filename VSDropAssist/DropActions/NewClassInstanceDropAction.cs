using VSDropAssist.Core;
using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    internal class NewClassInstanceDropAction : ConfigurableDropAction
    {
        public NewClassInstanceDropAction(IFormatExpressionService formatExpressionService, IIndentationService indentationService) : base(formatExpressionService,
            new DropActionConfiguration() { FormatExpression = "new %f%();", Delimiter="\n", AltMustBeDown=true, SupportsMembers = false, SupportsDroppingIntoClass = false, SupportsDroppingIntoMethod = true }, indentationService)
        {
        }

        
        
    }
}