using System.Collections.Generic;
using System.Text;

namespace VSDropAssist.DropActions
{
    public class FormatExpressionService : IFormatExpressionService
    {
        public string ReplaceText(string variableName, IEnumerable<Node> nodes, string formatExpression, string indentText)
        {
            var sb = new StringBuilder();
            var first = true;
            foreach (var n in nodes)
            {
                var expr = formatExpression;

                expr = expr.Replace("%m%", n.Member);
                expr = expr.Replace("%t%", n.Type);
                expr = expr.Replace("%n%", n.Namespace);
                expr = expr.Replace("%a%", n.Assembly);
                expr = expr.Replace("%v%", string.IsNullOrEmpty(variableName) ? n.Type : variableName);
                
                    sb.AppendFormat("{0}{1}",first ? string.Empty : indentText, expr);
                first = false;

            }
            return sb.ToString();
        }
    }
}