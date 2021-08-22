using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSDropAssist.Settings
{
    public partial class ucConfigurableDropAction : UserControl
    {
        private IDropAction _dropAction;

        public IDropAction DropAction
        {
            set
            {
                _dropAction = value;
                showDropAction();
            }
            get => _dropAction;
        }

        private void showDropAction()
        {
            var cda = _dropAction as IConfigurableDropAction;
            if (cda != null)
            {
                this.bsConfiguration.DataSource = cda.Configuration;
                this.DescriptionControl.Text = cda.Description;
                this.NameControl.Text = cda.Name;
                string keylabel = cda.Configuration.ToString(true, false, false);
                if (string.IsNullOrEmpty(keylabel)) keylabel = "<None>";
                this.PressedKeysControl.Text = keylabel;
            }
            else
            {
                this.NameControl.Text = _dropAction.GetType().Name;
            }

        }

        public ucConfigurableDropAction()
        {
            InitializeComponent();
        }
    }
}
