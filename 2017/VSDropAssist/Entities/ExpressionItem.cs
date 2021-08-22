using System;

namespace VSDropAssist.Entities
{
    public class ExpressionItem: IExpressionItem
    {
        public string Token { get; set; }
        public string Description { get; set; }
        public Func<INode, string, string> expr { get; set; }

        public ExpressionItem(string token, string description, Func<INode, string, string > expr)
        {
            Token = token;
            Description = description;
            this.expr = expr;
        }
    }
}