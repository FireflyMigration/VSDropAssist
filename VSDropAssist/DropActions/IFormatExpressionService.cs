using System.Collections.Generic;

namespace VSDropAssist.DropActions
{
    public interface IFormatExpressionService
    {
        string ReplaceText(IEnumerable< Node> nodes, string formatExpression, string indentText);
    }
}