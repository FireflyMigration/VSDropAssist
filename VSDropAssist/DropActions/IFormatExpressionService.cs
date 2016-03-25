using System.Collections.Generic;
using System.Collections.Specialized;

namespace VSDropAssist.DropActions
{
    public interface IFormatExpressionService
    {
        string ReplaceText(Node node, string formatExpression);
        IEnumerable<ExpressionItem> GetExpressionItems();
    }
}