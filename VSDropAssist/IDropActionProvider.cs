namespace VSDropAssist
{
    public interface IDropActionProvider
    {
        IDropAction GetAction(DropQuery qry);
    }
}