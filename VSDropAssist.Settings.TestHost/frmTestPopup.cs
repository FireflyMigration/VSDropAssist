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
    public partial class frmTestPopup : Form
    {
        private IFormatExpressionService _formatExpressionService;

        public frmTestPopup()
        {
            InitializeComponent();
            this.vsDropAssistPopupControl1.OnSettingUpdate += OnSettingUpdate;
            _formatExpressionService = new FormatExpressionService();
        }

        private void OnSettingUpdate(object sender, VSDropAssistPopupControl.SettingUpdateEventArgs args)
        {

            var nodes = new List<Node>();
            for(var i=0; i<5; i++)
            {
                nodes.Add(new Node() {Assembly = $"assembly{i}", Member = $"member{i}", Namespace = $"ns{i}", Type = $"type{i}"});

            }

            args.Example = _formatExpressionService.ReplaceText( nodes.FirstOrDefault(), args.SelectedSetting.FormatExpression);
        }

        private void frmTestPopup_Load(object sender, EventArgs e)
        {
            initData();
        }

        private void initData()
        {
            var s = new VSDropSettings();

            for(var i=0; i<10; i++)
            s.Settings.Add(new DropSetting($"Key{i}", $"Columns.Add(%v%.%m%{i});\n"));

            this.vsDropAssistPopupControl1.Data = s;

        }

        private void vsDropAssistPopupControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
