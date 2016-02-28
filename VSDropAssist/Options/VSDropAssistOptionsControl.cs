using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSDropAssist.Options
{
    public partial class VSDropAssistOptionsControl : UserControl
    {
        private VSDropAssistOptionsPage _optionsPage;

        public VSDropAssistOptionsControl()
        {
            InitializeComponent();
        }

        public void Init(VSDropAssistOptionsPage vsDropAssistOptionsPage)
        {
            _optionsPage = vsDropAssistOptionsPage;

            // show the settings
            this.bindingSource2.DataSource = _optionsPage.Settings;

        }

        private void ResetControl_Click(object sender, EventArgs e)
        {
            this.bindingSource2.EndEdit();

            if (MessageBox.Show("Warning. This will remove all custom settings and revert to defaults", "Reset", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            _optionsPage.ResetSettings();
        }
    }
}
