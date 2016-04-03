namespace VSDropAssist.Core.Entities
{
    public class CodeLine
    {
        public CodeLine()
        {
            Indent = true;
        }
        public string FormatExpression { get; set; }
        public string FormattedCode { get; set; }
        public Node SourceNode { get; set; }
        public int TokenStartPosition { get; set; }
        public int TokenLength { get; set; }
        public bool Indent { get;    set; }
    }
}