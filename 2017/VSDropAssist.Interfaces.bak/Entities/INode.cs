namespace VSDropAssist.Entities
{
    public interface INode
    {
        string Assembly { get; set; }
        string FullName { get; set; }
        bool IsClass { get; set; }
        string Member { get; set; }
        string Namespace { get; set; }
        string NormalisedFullName { get; }
        string NormalisedNamespace { get; set; }
        int StartLine { get; set; }
        string Type { get; set; }
        string VariableName { get; set; }

        bool Equals(object obj);
        int GetHashCode();
    }
}