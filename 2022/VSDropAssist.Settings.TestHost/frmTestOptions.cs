using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSDropAssist.DropActions;

namespace VSDropAssist.Settings.TestHost
{
    public partial class frmTestOptions : Form , IOptionsOwner
    {
        
        private IDropActionProvider _dropActionProvider;

        public VSDropSettings Settings => throw new NotImplementedException();

        public frmTestOptions()
        {
            InitializeComponent();
            initSettings();

            this.vsDropAssistOptionsControl1.Init(this , _dropActionProvider);
        }

        private void initSettings()
        {
            var fes = new FormatExpressionService();
            var types = typeof(ConfigurableDropAction).Assembly.GetTypes().Where(t => typeof(IConfigurableDropAction).IsAssignableFrom(t) && !t.IsAbstract);

            var instances = types.Select(t => Activator.CreateInstance(t, new[] { fes }));
            var das = instances.ToArray().Cast<IConfigurableDropAction>();

            _dropActionProvider = new DropActionProvider(das);
        }

        private void SaveControl_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void ResetSettings()
        {
            throw new NotImplementedException();
        }
    }
}
