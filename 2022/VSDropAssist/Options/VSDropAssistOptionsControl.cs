using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSDropAssist.DropActions;
using VSDropAssist.Settings;

namespace VSDropAssist.Options
{
    public partial class VSDropAssistOptionsControl : UserControl
    {
        private IOptionsOwner _owner;

        public VSDropAssistOptionsControl()
        {
            InitializeComponent();
        }

        public void Init(IOptionsOwner owner)
        {
            _owner = owner;

            // show the settings
            this.bsDropSettings.DataSource = _owner.Settings;

            showFormatTokens();
        }

        private void showFormatTokens()
        {
            var s = Application.Resolve<IFormatExpressionService>();

            this.bsFormatExpressions.DataSource  = s.GetExpressionItems();

        }

        private void ResetControl_Click(object sender, EventArgs e)
        {
            this.bsDropSettings.EndEdit();

            if (MessageBox.Show("Warning. This will remove all custom settings and revert to defaults", "Reset", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            _owner.ResetSettings();
        }
    }
}
