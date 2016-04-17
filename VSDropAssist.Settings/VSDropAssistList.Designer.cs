namespace VSDropAssist.Settings
{
    partial class VSDropAssistList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VSDropAssistList));
            this.grid = new System.Windows.Forms.DataGridView();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.settingsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.settingsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.settingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiftMustBeDownDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.controlMustBeDownDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.altMustBeDownDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.formatExpressionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectAfterDropDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.supportsMembersDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.supportsClassesDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.supportsDroppingIntoMethodDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.supportsDroppingIntoClassDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tokenToSelectAfterDropDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prefixDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suffixDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delimiterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectFirstLineOnlyDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingNavigator)).BeginInit();
            this.settingsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToOrderColumns = true;
            this.grid.AutoGenerateColumns = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.shiftMustBeDownDataGridViewCheckBoxColumn,
            this.controlMustBeDownDataGridViewCheckBoxColumn,
            this.altMustBeDownDataGridViewCheckBoxColumn,
            this.formatExpressionDataGridViewTextBoxColumn,
            this.selectAfterDropDataGridViewCheckBoxColumn,
            this.supportsMembersDataGridViewCheckBoxColumn,
            this.supportsClassesDataGridViewCheckBoxColumn,
            this.supportsDroppingIntoMethodDataGridViewCheckBoxColumn,
            this.supportsDroppingIntoClassDataGridViewCheckBoxColumn,
            this.tokenToSelectAfterDropDataGridViewTextBoxColumn,
            this.prefixDataGridViewTextBoxColumn,
            this.suffixDataGridViewTextBoxColumn,
            this.delimiterDataGridViewTextBoxColumn,
            this.selectFirstLineOnlyDataGridViewCheckBoxColumn});
            this.grid.DataSource = this.settingsBindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid.Location = new System.Drawing.Point(0, 25);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.Size = new System.Drawing.Size(867, 358);
            this.grid.TabIndex = 1;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Visible = false;
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Visible = false;
            // 
            // settingsBindingNavigatorSaveItem
            // 
            this.settingsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsBindingNavigatorSaveItem.Enabled = false;
            this.settingsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("settingsBindingNavigatorSaveItem.Image")));
            this.settingsBindingNavigatorSaveItem.Name = "settingsBindingNavigatorSaveItem";
            this.settingsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.settingsBindingNavigatorSaveItem.Text = "Save Data";
            this.settingsBindingNavigatorSaveItem.Visible = false;
            // 
            // settingsBindingNavigator
            // 
            this.settingsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.settingsBindingNavigator.BindingSource = this.settingsBindingSource;
            this.settingsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.settingsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.settingsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.settingsBindingNavigatorSaveItem});
            this.settingsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.settingsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.settingsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.settingsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.settingsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.settingsBindingNavigator.Name = "settingsBindingNavigator";
            this.settingsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.settingsBindingNavigator.Size = new System.Drawing.Size(867, 25);
            this.settingsBindingNavigator.TabIndex = 0;
            this.settingsBindingNavigator.Text = "bindingNavigator1";
            // 
            // settingsBindingSource
            // 
            this.settingsBindingSource.AllowNew = false;
            this.settingsBindingSource.DataSource = typeof(VSDropAssist.Settings.DropActionConfiguration);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.Frozen = true;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // shiftMustBeDownDataGridViewCheckBoxColumn
            // 
            this.shiftMustBeDownDataGridViewCheckBoxColumn.DataPropertyName = "ShiftMustBeDown";
            this.shiftMustBeDownDataGridViewCheckBoxColumn.HeaderText = "ShiftMustBeDown";
            this.shiftMustBeDownDataGridViewCheckBoxColumn.Name = "shiftMustBeDownDataGridViewCheckBoxColumn";
            this.shiftMustBeDownDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // controlMustBeDownDataGridViewCheckBoxColumn
            // 
            this.controlMustBeDownDataGridViewCheckBoxColumn.DataPropertyName = "ControlMustBeDown";
            this.controlMustBeDownDataGridViewCheckBoxColumn.HeaderText = "ControlMustBeDown";
            this.controlMustBeDownDataGridViewCheckBoxColumn.Name = "controlMustBeDownDataGridViewCheckBoxColumn";
            this.controlMustBeDownDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // altMustBeDownDataGridViewCheckBoxColumn
            // 
            this.altMustBeDownDataGridViewCheckBoxColumn.DataPropertyName = "AltMustBeDown";
            this.altMustBeDownDataGridViewCheckBoxColumn.HeaderText = "AltMustBeDown";
            this.altMustBeDownDataGridViewCheckBoxColumn.Name = "altMustBeDownDataGridViewCheckBoxColumn";
            this.altMustBeDownDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // formatExpressionDataGridViewTextBoxColumn
            // 
            this.formatExpressionDataGridViewTextBoxColumn.DataPropertyName = "FormatExpression";
            this.formatExpressionDataGridViewTextBoxColumn.HeaderText = "FormatExpression";
            this.formatExpressionDataGridViewTextBoxColumn.Name = "formatExpressionDataGridViewTextBoxColumn";
            this.formatExpressionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // selectAfterDropDataGridViewCheckBoxColumn
            // 
            this.selectAfterDropDataGridViewCheckBoxColumn.DataPropertyName = "SelectAfterDrop";
            this.selectAfterDropDataGridViewCheckBoxColumn.HeaderText = "SelectAfterDrop";
            this.selectAfterDropDataGridViewCheckBoxColumn.Name = "selectAfterDropDataGridViewCheckBoxColumn";
            this.selectAfterDropDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // supportsMembersDataGridViewCheckBoxColumn
            // 
            this.supportsMembersDataGridViewCheckBoxColumn.DataPropertyName = "SupportsMembers";
            this.supportsMembersDataGridViewCheckBoxColumn.HeaderText = "SupportsMembers";
            this.supportsMembersDataGridViewCheckBoxColumn.Name = "supportsMembersDataGridViewCheckBoxColumn";
            this.supportsMembersDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // supportsClassesDataGridViewCheckBoxColumn
            // 
            this.supportsClassesDataGridViewCheckBoxColumn.DataPropertyName = "SupportsClasses";
            this.supportsClassesDataGridViewCheckBoxColumn.HeaderText = "SupportsClasses";
            this.supportsClassesDataGridViewCheckBoxColumn.Name = "supportsClassesDataGridViewCheckBoxColumn";
            this.supportsClassesDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // supportsDroppingIntoMethodDataGridViewCheckBoxColumn
            // 
            this.supportsDroppingIntoMethodDataGridViewCheckBoxColumn.DataPropertyName = "SupportsDroppingIntoMethod";
            this.supportsDroppingIntoMethodDataGridViewCheckBoxColumn.HeaderText = "SupportsDroppingIntoMethod";
            this.supportsDroppingIntoMethodDataGridViewCheckBoxColumn.Name = "supportsDroppingIntoMethodDataGridViewCheckBoxColumn";
            this.supportsDroppingIntoMethodDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // supportsDroppingIntoClassDataGridViewCheckBoxColumn
            // 
            this.supportsDroppingIntoClassDataGridViewCheckBoxColumn.DataPropertyName = "SupportsDroppingIntoClass";
            this.supportsDroppingIntoClassDataGridViewCheckBoxColumn.HeaderText = "SupportsDroppingIntoClass";
            this.supportsDroppingIntoClassDataGridViewCheckBoxColumn.Name = "supportsDroppingIntoClassDataGridViewCheckBoxColumn";
            this.supportsDroppingIntoClassDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // tokenToSelectAfterDropDataGridViewTextBoxColumn
            // 
            this.tokenToSelectAfterDropDataGridViewTextBoxColumn.DataPropertyName = "TokenToSelectAfterDrop";
            this.tokenToSelectAfterDropDataGridViewTextBoxColumn.HeaderText = "TokenToSelectAfterDrop";
            this.tokenToSelectAfterDropDataGridViewTextBoxColumn.Name = "tokenToSelectAfterDropDataGridViewTextBoxColumn";
            this.tokenToSelectAfterDropDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prefixDataGridViewTextBoxColumn
            // 
            this.prefixDataGridViewTextBoxColumn.DataPropertyName = "Prefix";
            this.prefixDataGridViewTextBoxColumn.HeaderText = "Prefix";
            this.prefixDataGridViewTextBoxColumn.Name = "prefixDataGridViewTextBoxColumn";
            this.prefixDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // suffixDataGridViewTextBoxColumn
            // 
            this.suffixDataGridViewTextBoxColumn.DataPropertyName = "Suffix";
            this.suffixDataGridViewTextBoxColumn.HeaderText = "Suffix";
            this.suffixDataGridViewTextBoxColumn.Name = "suffixDataGridViewTextBoxColumn";
            this.suffixDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // delimiterDataGridViewTextBoxColumn
            // 
            this.delimiterDataGridViewTextBoxColumn.DataPropertyName = "Delimiter";
            this.delimiterDataGridViewTextBoxColumn.HeaderText = "Delimiter";
            this.delimiterDataGridViewTextBoxColumn.Name = "delimiterDataGridViewTextBoxColumn";
            this.delimiterDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // selectFirstLineOnlyDataGridViewCheckBoxColumn
            // 
            this.selectFirstLineOnlyDataGridViewCheckBoxColumn.DataPropertyName = "SelectFirstLineOnly";
            this.selectFirstLineOnlyDataGridViewCheckBoxColumn.HeaderText = "SelectFirstLineOnly";
            this.selectFirstLineOnlyDataGridViewCheckBoxColumn.Name = "selectFirstLineOnlyDataGridViewCheckBoxColumn";
            this.selectFirstLineOnlyDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // VSDropAssistList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.settingsBindingNavigator);
            this.Name = "VSDropAssistList";
            this.Size = new System.Drawing.Size(867, 383);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingNavigator)).EndInit();
            this.settingsBindingNavigator.ResumeLayout(false);
            this.settingsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource settingsBindingSource;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton settingsBindingNavigatorSaveItem;
        private System.Windows.Forms.BindingNavigator settingsBindingNavigator;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn shiftMustBeDownDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn controlMustBeDownDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn altMustBeDownDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formatExpressionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectAfterDropDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn supportsMembersDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn supportsClassesDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn supportsDroppingIntoMethodDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn supportsDroppingIntoClassDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tokenToSelectAfterDropDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prefixDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suffixDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delimiterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectFirstLineOnlyDataGridViewCheckBoxColumn;
    }
}
