using System.Collections.Generic;
using VSDropAssist.Entities;

namespace VSDropAssist
{
    public interface IFormatExpressionService
    {
        string ReplaceText(INode node, string formatExpression);
        IEnumerable<IExpressionItem> GetExpressionItems();
        int GetTokenStart(INode node, string expr, string token);
        int GetTokenLength(INode n, string token);
    }
}