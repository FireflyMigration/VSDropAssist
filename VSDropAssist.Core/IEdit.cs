namespace VSDropAssist.Core
{
    public interface IEdit
    {
        void Insert(int  position, string textToInsert);
        void Apply();
    }
}