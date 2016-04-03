namespace VSDropAssist.Core
{
    public interface IDragDropInfo
    {
        IKeyStates KeyStates { get; }

        object GetData(string dataformat);
        bool GetDataPresent(string dataformat);
        ILine GetDroppingLine();
//        IEndPoint GetEndPoint();
        int GetStartPosition();
        object  GetDataObject();
    }
}