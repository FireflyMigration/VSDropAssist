using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using VSDropAssist.Core;
using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    internal class ColumnsAddDropAction : ConfigurableDropAction 
    {


        

        public ColumnsAddDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService
            , new DropActionConfiguration() {FormatExpression = "Columns.Add(%v%.%m%);", SupportsClasses = false, ShiftMustBeDown = true, SelectFirstLineOnly=false  })
        {
        }
    }
}