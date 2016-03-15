using System.Collections.Generic;

namespace VSDropAssist.DropActions
{
    public interface IFormatExpressionService
    {
        string ReplaceText(Node node, string formatExpression, string indentText);
    }
}