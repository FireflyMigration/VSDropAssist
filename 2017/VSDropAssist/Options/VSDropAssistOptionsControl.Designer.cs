using VSDropAssist.Entities;
using VSDropAssist.Settings;

namespace VSDropAssist.Options
{
    partial class VSDropAssistOptionsControl
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
            this.grdSettings = new System.Windows.Forms.DataGridView();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formatExpressionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bsDropSettings = new System.Windows.Forms.BindingSource(this.components);
            this.ResetControl = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdFormatExpressions = new System.Windows.Forms.DataGridView();
            this.tokenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFormatExpressions = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDropSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFormatExpressions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFormatExpressions)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdSettings
            // 
            this.grdSettings.AutoGenerateColumns = false;
            this.grdSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyDataGridViewTextBoxColumn,
            this.formatExpressionDataGridViewTextBoxColumn});
            this.grdSettings.DataSource = this.settingsBindingSource;
            this.grdSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSettings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdSettings.Location = new System.Drawing.Point(0, 0);
            this.grdSettings.Name = "grdSettings";
            this.grdSettings.RowHeadersVisible = false;
            this.grdSettings.Size = new System.Drawing.Size(690, 171);
            this.grdSettings.TabIndex = 0;
            // 
            // keyDataGridViewTextBoxColumn
            // 
            this.keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            this.keyDataGridViewTextBoxColumn.HeaderText = "Key";
            this.keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            // 
            // formatExpressionDataGridViewTextBoxColumn
            // 
            this.formatExpressionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.formatExpressionDataGridViewTextBoxColumn.DataPropertyName = "FormatExpression";
            this.formatExpressionDataGridViewTextBoxColumn.HeaderText = "FormatExpression";
            this.formatExpressionDataGridViewTextBoxColumn.Name = "formatExpressionDataGridViewTextBoxColumn";
            // 
            // settingsBindingSource
            // 
            this.settingsBindingSource.DataMember = "Settings";
            this.settingsBindingSource.DataSource = this.bsDropSettings;
            // 
            // bsDropSettings
            // 
            this.bsDropSettings.DataSource = typeof(VSDropAssist.Settings.VSDropSettings);
            // 
            // ResetControl
            // 
            this.ResetControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetControl.Location = new System.Drawing.Point(9, 46);
            this.ResetControl.Name = "ResetControl";
            this.ResetControl.Size = new System.Drawing.Size(75, 23);
            this.ResetControl.TabIndex = 3;
            this.ResetControl.Text = "Reset";
            this.ResetControl.UseVisualStyleBackColor = true;
            this.ResetControl.Click += new System.EventHandler(this.ResetControl_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdSettings);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdFormatExpressions);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(690, 247);
            this.splitContainer1.SplitterDistance = 171;
            this.splitContainer1.TabIndex = 4;
            // 
            // grdFormatExpressions
            // 
            this.grdFormatExpressions.AllowUserToAddRows = false;
            this.grdFormatExpressions.AllowUserToDeleteRows = false;
            this.grdFormatExpressions.AutoGenerateColumns = false;
            this.grdFormatExpressions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFormatExpressions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tokenDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.grdFormatExpressions.DataSource = this.bsFormatExpressions;
            this.grdFormatExpressions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFormatExpressions.Location = new System.Drawing.Point(0, 0);
            this.grdFormatExpressions.MultiSelect = false;
            this.grdFormatExpressions.Name = "grdFormatExpressions";
            this.grdFormatExpressions.ReadOnly = true;
            this.grdFormatExpressions.RowHeadersVisible = false;
            this.grdFormatExpressions.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdFormatExpressions.Size = new System.Drawing.Size(603, 72);
            this.grdFormatExpressions.TabIndex = 6;
            // 
            // tokenDataGridViewTextBoxColumn
            // 
            this.tokenDataGridViewTextBoxColumn.DataPropertyName = "Token";
            this.tokenDataGridViewTextBoxColumn.HeaderText = "Token";
            this.tokenDataGridViewTextBoxColumn.Name = "tokenDataGridViewTextBoxColumn";
            this.tokenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // bsFormatExpressions
            // 
            this.bsFormatExpressions.DataSource = typeof(ExpressionItem);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ResetControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(603, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(87, 72);
            this.panel1.TabIndex = 5;
            // 
            // VSDropAssistOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "VSDropAssistOptionsControl";
            this.Size = new System.Drawing.Size(690, 247);
            ((System.ComponentModel.ISupportInitialize)(this.grdSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDropSettings)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFormatExpressions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFormatExpressions)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsDropSettings;
        private System.Windows.Forms.DataGridView grdSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formatExpressionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource settingsBindingSource;
        private System.Windows.Forms.Button ResetControl;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource bsFormatExpressions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tokenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView grdFormatExpressions;
    }
}
