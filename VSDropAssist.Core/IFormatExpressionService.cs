using System.Collections.Generic;
using VSDropAssist.Core.Entities;

namespace VSDropAssist.Core
{
    public interface IFormatExpressionService
    {
        string ReplaceText(Node node, string formatExpression);
        IEnumerable<ExpressionItem> GetExpressionItems();
        int GetTokenStart(Node node, string expr, string token);
        int GetTokenLength(Node n, string token);
    }
}