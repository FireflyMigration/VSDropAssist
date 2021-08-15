namespace VSDropAssist.Entities
{
    public class CodeLine : ICodeLine
    {
        public string FormatExpression { get; set; }
        public string FormattedCode { get; set; }
        public INode SourceNode { get; set; }
        public int TokenStartPosition { get; set; }
        public int TokenLength { get; set; }
    }
}