using System.Collections.Generic;

namespace VSDropAssist.DropActions
{
    public interface IFormatExpressionService
    {
        string ReplaceText(string variableName,IEnumerable< Node> nodes, string formatExpression, string indentText);
    }
}