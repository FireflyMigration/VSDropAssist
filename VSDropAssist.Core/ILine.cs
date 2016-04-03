namespace VSDropAssist.Core
{
    public interface ILine
    {
        int LineNumber { get; }

        string GetLineBreakText();
        string GetText();
        object RealObject { get; }
    }
}