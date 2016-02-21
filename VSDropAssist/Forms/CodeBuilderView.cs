using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.Text.Differencing;
using VSDropAssist.Core;

namespace VSDropAssist.Forms
{
   
    public partial class CodeBuilderView : Form
    {
        private CodeBuilderViewModel _model;

        public CodeBuilderView(IViewModel model)

        {
            
            InitializeComponent();

            Model = (CodeBuilderViewModel) model;
        }

        private CodeBuilderViewModel Model {
            get
            {
                return _model ;
            }
            set
            {
                _model = value;
                this.CodeBuilderVMBindingSource.DataSource = _model ;
                
            }
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            if(this.Model.OkCommand!=null) this.Model.OkCommand.Execute();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (this.Model.CancelCommand  != null) this.Model.CancelCommand.Execute();
        }
    }
}
