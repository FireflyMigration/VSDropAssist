using System.Collections.Generic;

namespace VSDropAssist
{
    public interface IDropActionProvider
    {
        IEnumerable<IDropAction> GetActions();
        IDropAction GetAction(IDropQuery qry);
    }
}