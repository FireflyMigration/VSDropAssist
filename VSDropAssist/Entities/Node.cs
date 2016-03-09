namespace VSDropAssist
{
    public class Node
    {
        public Node()
        {
            IsClass = true;
        }
        private string _member;
        public string Namespace { get; set; }
        public string Type { get; set; }

        public string Member
        {
            get { return _member; }
            set
            {
                _member = value;
                IsClass = (string.IsNullOrEmpty(_member));
            }
        }

        public string Assembly { get; set; }

        public int StartLine { get; set; }
        public bool IsClass { get; set; }
        public string FullName { get; set; }
    }
}