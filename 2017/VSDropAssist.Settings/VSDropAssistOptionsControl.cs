using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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


            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Name",
                HeaderText = "Name",
                Width = 150,
                DataPropertyName = "Name"
            });
            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Description",
                HeaderText = "Description",
                Width = 300,
                DataPropertyName = "Description"
            });
            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "Shift",
                HeaderText = "Shift",
                Width = 60,
                DataPropertyName = "ShiftMustBeDown"
            });
            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "Control",
                HeaderText = "Control",
                Width = 60,
                DataPropertyName = "ControlMustBeDown"
            });
            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "Alt",
                HeaderText = "Alt",
                Width = 60,
                DataPropertyName = "AltMustBeDown"
            });

            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "Classes",
                HeaderText = "Classes",
                Width = 60,
                DataPropertyName = "SupportsClasses"
            });

            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "Columns",
                HeaderText = "Columns",
                Width = 60,
                DataPropertyName = "SupportsMembers"
            });

            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "OntoClass",
                HeaderText = "Onto Class",
                Width = 60,
                DataPropertyName = "SupportsDroppingIntoClass"
            });

            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                Name = "Method",
                HeaderText = "Into Method",
                Width = 60,
                DataPropertyName = "SupportsDroppingIntoMethod"
            });
            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.DataSource = dropActionProvider.GetActions().Cast<IConfigurableDropAction>()
                .Select(x => new ConfigurableDropActionViewModel(x)).ToList();

        }

    }

    /// <summary>
    /// Flattened version of a configurable dropaction for easy display in the grid
    /// </summary>
    public class ConfigurableDropActionViewModel
    {
        private readonly IConfigurableDropAction _dropAction;

        public ConfigurableDropActionViewModel(IConfigurableDropAction dropAction)
        {
            _dropAction = dropAction;
        }

        public string Name => _dropAction.Name;
        public string Description => _dropAction.Description;

        public bool SupportsDroppingIntoMethod => _dropAction.Configuration.SupportsDroppingIntoMethod;
        public bool SupportsDroppingIntoClass => _dropAction.Configuration.SupportsDroppingIntoClass;

        public bool SupportsClasses => _dropAction.Configuration.SupportsClasses;
        public bool SupportsMembers => _dropAction.Configuration.SupportsMembers;
        public bool AltMustBeDown => _dropAction.Configuration.AltMustBeDown;
        public bool ShiftMustBeDown => _dropAction.Configuration.ShiftMustBeDown;
        public bool ControlMustBeDown => _dropAction.Configuration.ControlMustBeDown;

        
    }
    
}
