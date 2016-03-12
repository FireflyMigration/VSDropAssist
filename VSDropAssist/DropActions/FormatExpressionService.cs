using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSDropAssist.DropActions
{
    public class FormatExpressionService : IFormatExpressionService
    {
        public string ReplaceText( IEnumerable<Node> nodes, string formatExpression, string indentText)
        {
            var text = new List<string>();

            var first = true;
            foreach (var n in nodes)
            {
                var expr = formatExpression;

                var v = n.VariableName;
               

                expr = expr.Replace("%m%", n.Member);
                expr = expr.Replace("%t%", n.Type);
                expr = expr.Replace("%n%", n.Namespace);
                expr = expr.Replace("%a%", n.Assembly);
                expr = expr.Replace("%f%", n.FullName );
                expr = expr.Replace("%v%",v);
                text.Add(string.Format("{0}{1}", first ? string.Empty : indentText, expr));
                  
                first = false;

            }
            return string.Join("",text.Distinct());
        }
    }
}