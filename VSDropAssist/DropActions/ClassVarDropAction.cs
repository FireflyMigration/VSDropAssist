using System;
using System.Collections.Generic;
using System.Linq;

namespace VSDropAssist.DropActions
{
    internal abstract class ClassOnlyWithSelectDropAction : ConfigurableDropAction
    {
     
        protected  ClassOnlyWithSelectDropAction(IFormatExpressionService formatExpressionService, IDropActionConfiguration config ) : base(formatExpressionService,config  )
        {
        }
    }
    internal class ClassVarDropAction : ClassOnlyWithSelectDropAction
    {
        public ClassVarDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService
            , new DropActionConfiguration()
            {
                FormatExpression = "var %v% = new %f%();", Delimiter = "\n", SupportsMembers = false, 
                SupportsDroppingIntoMethod=true, SupportsDroppingIntoClass = false, ShiftMustBeDown=true  }
            )
        {
        }
        

    }
}