using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace VSDropAssist.Settings
{
    public partial class VSDropAssistOptionsControl : UserControl
    {
        private IOptionsOwner _optionsPage;

        public VSDropAssistOptionsControl()
        {
            InitializeComponent();
        }

        public void Init(IOptionsOwner vsDropAssistOptionsPage, IDropActionProvider dropActionProvider)
        {
            _optionsPage = vsDropAssistOptionsPage;

            displayActions(dropActionProvider);
            
        }

        private void displayActions(IDropActionProvider dropActionProvider)
        {
            foreach(var da in dropActionProvider.GetActions())
            {
                var x = new ucConfigurableDropAction();
                x.DropAction = da;
                x.Width = this.flowLayoutPanel1.Width - 30;
                this.Controls.Add(x);

                x.Visible = true;
                x.Parent = this.flowLayoutPanel1;
            }
        }
    }
}
