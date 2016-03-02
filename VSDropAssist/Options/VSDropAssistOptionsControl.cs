﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            this.bindingSource2.DataSource = _owner.Settings;

        }

        private void ResetControl_Click(object sender, EventArgs e)
        {
            this.bindingSource2.EndEdit();

            if (MessageBox.Show("Warning. This will remove all custom settings and revert to defaults", "Reset", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            _owner.ResetSettings();
        }
    }
}
