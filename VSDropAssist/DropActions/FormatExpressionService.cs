using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSDropAssist.DropActions
{
    public class FormatExpressionService : IFormatExpressionService
    {
        public string ReplaceText( Node n, string formatExpression, string indentText)
        {
    
                var expr = formatExpression;

                var v = n.VariableName;
               

                expr = expr.Replace("%m%", n.Member);
                expr = expr.Replace("%t%", n.Type);
                expr = expr.Replace("%n%", n.Namespace);
                expr = expr.Replace("%a%", n.Assembly);
                expr = expr.Replace("%f%", n.FullName );
                expr = expr.Replace("%v%",v);
            return indentText + expr;
        }
    }
}