using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace VSDropAssist.Settings
{
    public partial class VSDropAssistOptionsList : UserControl
    {
        private IOptionsOwner _optionsPage;

        public VSDropAssistOptionsList()
        {
            InitializeComponent();
        }

        public void Init(IOptionsOwner vsDropAssistOptionsPage)
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
