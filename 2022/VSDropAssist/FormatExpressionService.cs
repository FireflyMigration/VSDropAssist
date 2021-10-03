using System;
using System.Collections.Generic;
using System.Linq;
using VSDropAssist.Entities;

namespace VSDropAssist
{
    public class FormatExpressionService : IFormatExpressionService
    {
        private List<ExpressionItem> _expressionItems = new List<ExpressionItem>(); 
        public FormatExpressionService()
        {
            initExpressionItems();
        }

        private void initExpressionItems()
        {
            _expressionItems.AddRange(new [] {
                new ExpressionItem("%m%", "Member (ie. AddressLine1)", (n, text) => text.Replace("%m%", n.Member ) ),
                new ExpressionItem("%t%", "Type (ie. Customer)", (n, text) => text.Replace("%t%", n.Type)),
                new ExpressionItem("%N%", "Namespace (ie. Northwind.Models)", (n, text) => text.Replace("%N%", n.Namespace ) ),
                new ExpressionItem("%n%", "Namespace (normalised)", (n, text) => text.Replace("%n%", n.NormalisedNamespace) ),
                new ExpressionItem("%a%", "Assembly (ie. Northwind)", (n, text) => text.Replace("%a%", n.Assembly ) ),
                new ExpressionItem("%F%", "Full Typename (ie. Northwind.Models.Customer)", (n, text) => text.Replace("%F%", n.FullName ) ),
                new ExpressionItem("%f%", "Full Typename (normalised)", (n, text) => text.Replace("%f%", n.NormalisedFullName ) ),
                new ExpressionItem("%v%", "Variable", (n, text) => text.Replace("%v%", n.VariableName ) ),
                
                });

        }

        public int GetTokenLength(Node n, string token)
        {
            var item = _expressionItems.FirstOrDefault(x => x.Token.Equals(token));
            if (item  == null) return 0;

            var tmpExpression = item.expr(n, item.Token);

            return tmpExpression.Length;
        }

        public string ReplaceText( Node n, string formatExpression)
        {
    
                var expr = formatExpression;

                
            foreach (var e in _expressionItems)
            {
              
                expr = e.expr(n, expr);
            }
            return expr;
        }

        public IEnumerable<ExpressionItem> GetExpressionItems()
        {
            return _expressionItems;
            
        }

        public int GetTokenStart(Node node, string expr, string token)
        {
            var g = Guid.NewGuid();
            var tmpExpr = expr;
            foreach (var e in _expressionItems)
            {
                if (e.Token  != token)
                {
                    tmpExpr = e.expr(node, tmpExpr);
                }
                else
                {
                    tmpExpr = tmpExpr.Replace(token, g.ToString());
                }
            }

            return tmpExpr.IndexOf(g.ToString());
        }
    }
}