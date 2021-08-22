namespace VSDropAssist.Entities
{
    public interface ICodeLine
    {
        string FormatExpression { get; set; }
        string FormattedCode { get; set; }
        INode SourceNode { get; set; }
        int TokenLength { get; set; }
        int TokenStartPosition { get; set; }
    }
}