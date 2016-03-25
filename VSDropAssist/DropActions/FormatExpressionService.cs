using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace VSDropAssist.DropActions
{
    public class ExpressionItem
    {
        public string Token { get; set; }
        public string Description { get; set; }
        public Func<Node, string, string> expr { get; set; }

        public ExpressionItem(string token, string description, Func<Node, string, string > expr)
        {
            Token = token;
            Description = description;
            this.expr = expr;
        }
    }
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

        public string ReplaceText( Node n, string formatExpression)
        {
    
                var expr = formatExpression;

                var v = n.VariableName;
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
    }
}