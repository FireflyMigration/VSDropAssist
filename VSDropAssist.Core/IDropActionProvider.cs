namespace VSDropAssist.Core
{
    public interface IDropActionProvider
    {
        IDropAction GetAction(IDropQuery qry);
    }
}