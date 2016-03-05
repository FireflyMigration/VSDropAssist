namespace VSDropAssist
{
    public class Node
    {
        public string Namespace { get; set; }
        public string Type { get; set; }
        public string Member { get; set; }
        public string Assembly { get; set; }

        public int StartLine { get; set; }
    }
}