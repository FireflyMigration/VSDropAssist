namespace VSDropAssist.Options
{
    partial class EditOptionsPopup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CancelControl = new System.Windows.Forms.Button();
            this.OkControl = new System.Windows.Forms.Button();
            this.vsDropAssistPopupControl1 = new VSDropAssist.Settings.VSDropAssistPopupControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.vsDropAssistPopupControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CancelControl);
            this.splitContainer1.Panel2.Controls.Add(this.OkControl);
            this.splitContainer1.Size = new System.Drawing.Size(898, 473);
            this.splitContainer1.SplitterDistance = 807;
            this.splitContainer1.TabIndex = 1;
            // 
            // CancelControl
            // 
            this.CancelControl.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelControl.Location = new System.Drawing.Point(4, 43);
            this.CancelControl.Name = "CancelControl";
            this.CancelControl.Size = new System.Drawing.Size(75, 23);
            this.CancelControl.TabIndex = 1;
            this.CancelControl.Text = "Cancel";
            this.CancelControl.UseVisualStyleBackColor = true;
            // 
            // OkControl
            // 
            this.OkControl.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkControl.Location = new System.Drawing.Point(4, 13);
            this.OkControl.Name = "OkControl";
            this.OkControl.Size = new System.Drawing.Size(75, 23);
            this.OkControl.TabIndex = 0;
            this.OkControl.Text = "Ok";
            this.OkControl.UseVisualStyleBackColor = true;
            // 
            // vsDropAssistPopupControl1
            // 
            this.vsDropAssistPopupControl1.Location = new System.Drawing.Point(12, 23);
            this.vsDropAssistPopupControl1.Name = "vsDropAssistPopupControl1";
            this.vsDropAssistPopupControl1.Size = new System.Drawing.Size(774, 434);
            this.vsDropAssistPopupControl1.TabIndex = 0;
            // 
            // EditOptionsPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 473);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditOptionsPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Settings.VSDropAssistPopupControl vsDropAssistPopupControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button CancelControl;
        private System.Windows.Forms.Button OkControl;
    }
}