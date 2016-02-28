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
using VSDropAssist.Options;

namespace VSDropAssist.DropActions
{
 
    public partial class DropActionDialog : Form
    {
        public DropActionDialog()
        {
            InitializeComponent();
        }

    
        public Settings GetSettings(Settings settings)
        {
            this.bsSettings.DataSource = settings;
            this.ShowDialog();

            return settings;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showSetting(this.comboBox1.SelectedItem as string );
        }

        private void showSetting(string selectedItemKey)
        {
            if (selectedItemKey == null)
            {this.bsSettings.RemoveFilter();

                return;
            }

            this.bsSettings.Filter = "Key='" + selectedItemKey + "'";
        }
    }

    public class Settings : INotifyPropertyChanged
    {
        public string _variableName;

        public string _formatExpression;
       
        public VSDropSettings AvailableSettings { get; set; }

        public Settings(VSDropSettings avaialbleSettings)
        {
            this.AvailableSettings = avaialbleSettings;
        }
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
