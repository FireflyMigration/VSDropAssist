using System.Collections.Generic;
using System.Text;

namespace VSDropAssist.DropActions
{
    internal class MemberUpdateDropAction : ConfigurableDropAction
    {
        
        public MemberUpdateDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService
            , new DropActionConfiguration() { AltMustBeDown=true, FormatExpression = "%v%.%m%.Value = ;" , SupportsMembers = true, SupportsDroppingIntoMethod = true, SupportsDroppingIntoClass = false , SelectFirstLineOnly=false  })
        {
        }
    }
    
}