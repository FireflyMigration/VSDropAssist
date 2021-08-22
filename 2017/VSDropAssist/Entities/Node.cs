using System.Linq;

namespace VSDropAssist.Entities
{
    public class Node : INode
    {
        protected bool Equals(Node other)
        {
            return string.Equals(_member, other._member) 
                && string.Equals(_type, other._type) 
                && string.Equals(_ns, other._ns) 
                && string.Equals(_assembly, other._assembly) 
               // && _startLine == other._startLine
                && _isClass == other._isClass
                && string.Equals(_fullName, other._fullName) 
                && string.Equals(_variableName, other._variableName) && string.Equals(NormalisedNamespace, other.NormalisedNamespace);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_member != null ? _member.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_type != null ? _type.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_ns != null ? _ns.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_assembly != null ? _assembly.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ _startLine;
                hashCode = (hashCode*397) ^ _isClass.GetHashCode();
                hashCode = (hashCode*397) ^ (_fullName != null ? _fullName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (_variableName != null ? _variableName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (NormalisedNamespace != null ? NormalisedNamespace.GetHashCode() : 0);
                return hashCode;
            }
        }

        public Node()
        {
            IsClass = true;
        }
        private string _member;
        private string _type;
        private string _ns;
        private string _assembly;
        private int _startLine;
        private bool _isClass;
        private string _fullName;
        private string _variableName;

        public string Namespace
        {
            get { return _ns; }
            set { _ns = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value;}
        }
        

        public string Member
        {
            get { return _member; }
            set
            {
                _member = value;
                IsClass = (string.IsNullOrEmpty(_member));
            }
        }

        public string Assembly
        {
            get { return _assembly; }
            set { _assembly = value; }
        }

        public int StartLine
        {
            get { return _startLine; }
            set { _startLine = value; }
        }

        public bool IsClass
        {
            get { return _isClass; }
            set { _isClass = value; }
        }

        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(_fullName))
                {
                    return string.Format("{0}.{1}", _ns,_type);
                }
                return _fullName;
            }
            set
            {
              
                _fullName = value;
            }
        }

        public string VariableName

        {
            get
            {
                if (string.IsNullOrEmpty(_variableName ))
                {
                    var v = this.Type;

                    if (v.Contains(".")) v = v.Split(new[] { '.' }).Last();
                    return v;
                }

                return _variableName;
            }
            set { _variableName = value; }
        }

        public string NormalisedNamespace { get; set; }

        public string NormalisedFullName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.NormalisedNamespace))
                    return string.Format("{0}.{1}", this.NormalisedNamespace, this.Type);
                return this.Type;
            }
        }
    }
}