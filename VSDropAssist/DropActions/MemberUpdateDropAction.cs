using System.Collections.Generic;
using System.Text;
using VSDropAssist.Core;
using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    internal class MemberUpdateDropAction : ConfigurableDropAction
    {
        
        public MemberUpdateDropAction(IFormatExpressionService formatExpressionService, IIndentationService indentationService) : base(formatExpressionService
            , new DropActionConfiguration() { AltMustBeDown=true, FormatExpression = "%v%.%m%.Value = ;" , SupportsMembers = true, SupportsDroppingIntoMethod = true, SupportsDroppingIntoClass = false , SelectFirstLineOnly=false  }, indentationService )
        {
        }
    }
    
}