using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VSDropAssist.Core;

namespace VSDropAssist.Forms
{
    public class CodeBuilderViewModel :ViewModelBase
    {
        private string _exampleText;
        private string _builderText;
        private ObservableCollection<Node> _nodes;
        public OkCommand OkCommand { get; set; }
        public CancelCommand CancelCommand { get; set; }

        public bool OkEnabled { get { return OkCommand != null && OkCommand.Enabled; } }
        public bool CancelEnabled { get { return CancelCommand != null && CancelCommand.Enabled; } }

        public ObservableCollection<Node> Nodes
        {
            get { return _nodes; }
            set
            {
                _nodes = value; 
                OnPropertyChanged();
            }
        }

        public string BuilderText
        {
            get { return _builderText; }
            set
            {
                _builderText = value; 
                OnPropertyChanged();
            }
        }

        public string ExampleText
        {
            get { return _exampleText; }
            set
            {
                _exampleText = value;
                OnPropertyChanged();
            }
        }

        public CodeBuilderViewModel(IList<Node> nodes)
        {
            Nodes = new ObservableCollection<Node>(nodes );
        }

     
    }
}