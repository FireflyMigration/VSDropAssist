using System.Collections.Generic;
using System.Text;

namespace VSDropAssist.DropActions
{
    public class FormatExpressionService : IFormatExpressionService
    {
        public string ReplaceText(string variableName, IEnumerable<Node> nodes, string formatExpression)
        {
            var sb = new StringBuilder();

            foreach (var n in nodes)
            {
                var expr = formatExpression;

                expr = expr.Replace("%m%", n.Member);
                expr = expr.Replace("%t%", n.Type);
                expr = expr.Replace("%n%", n.Namespace);
                expr = expr.Replace("%a%", n.Assembly);
                expr = expr.Replace("%v%", string.IsNullOrEmpty(variableName) ? n.Type.ToLower() : variableName);
                sb.AppendFormat("{0}", expr);

            }
            return sb.ToString();
        }
    }
}