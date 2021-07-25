namespace VSDropAssist.Entities
{
    public class CodeLine
    {
        public string FormatExpression { get; set; }
        public string FormattedCode { get; set; }
        public Node SourceNode { get; set; }
        public int TokenStartPosition { get; set; }
        public int TokenLength { get; set; }
    }
}