using System;

namespace VSDropAssist.Entities
{
    public interface IExpressionItem
    {
        string Description { get; set; }
        Func<INode, string, string> expr { get; set; }
        string Token { get; set; }
    }
}