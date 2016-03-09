using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VSDropAssist.DropActions
{
    internal class InsertColumnsAddDropAction : ClassMemberDropAction
    {


        private const string FORMAT = "Columns.Add(%v%.%m%);\n";
        protected override string GetFormatString()
        {
            return FORMAT;
        }
     

        public InsertColumnsAddDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }
    }
}