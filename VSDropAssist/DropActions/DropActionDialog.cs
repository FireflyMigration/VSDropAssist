using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSDropAssist.Annotations;

namespace VSDropAssist.DropActions
{
 
    public partial class DropActionDialog : Form
    {
        public DropActionDialog()
        {
            InitializeComponent();
        }

    
        public Settings GetSettings(Settings defaults)
        {
            this.bindingSource1.DataSource = defaults;
            this.ShowDialog();

            return defaults;
        }

       
    }

    public class Settings : INotifyPropertyChanged
    {
        public string _variableName;

        public string _formatExpression;
       
        public class EvaluateArgs : EventArgs
        {
            public string FormatExpression { get; private set; }
            public string VariableName { get; private set; }
            public string Example;

            public EvaluateArgs(string formatExpression, string variableName)
            {
                this.FormatExpression = formatExpression;
                this.VariableName = variableName;
            }
        }

        public EventHandler<EvaluateArgs> EvaluateEventHandler;

      

        public string FormatExpression
        {
            get { return _formatExpression; }
            set
            {
                _formatExpression = value;
               
                OnPropertyChanged();
                doEvaluate();
            }
        }

        public string Example
        {
            get { return _example; }
            set
            {
                _example = value;
                OnPropertyChanged();
            }
        }

        public string VariableName
        {
            get { return _variableName; }
            set
            {
                _variableName = value;
                OnPropertyChanged();
                doEvaluate();
            }
        }

        public void doEvaluate()
        {
            var e = EvaluateEventHandler;
            if (e != null)
            {
                var evaluateArgs = new EvaluateArgs( this.FormatExpression, this.VariableName);
                e(this, evaluateArgs);

                this.Example = evaluateArgs.Example;
            }
        }

        public string _example;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
