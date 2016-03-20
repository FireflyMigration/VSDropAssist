using System;
using System.Linq;
using Microsoft.VisualStudio.Shell.Interop;

namespace VSDropAssist
{
    public class Node
    {
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