namespace VSDropAssist.Settings
{
    public interface IOptionsOwner
    {
        VSDropSettings Settings { get;  }
        void ResetSettings();
    }
    
}