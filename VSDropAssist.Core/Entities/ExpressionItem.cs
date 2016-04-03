using System;

namespace VSDropAssist.Core.Entities
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
}