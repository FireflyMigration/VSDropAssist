using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    partial class DropActionDialog
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
            this.OkControl = new System.Windows.Forms.Button();
            this.cancelControl = new System.Windows.Forms.Button();
            this.vsDropAssistPopupControl1 = new VSDropAssist.Settings.VSDropAssistPopupControl();
            this.SuspendLayout();
            // 
            // OkControl
            // 
            this.OkControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkControl.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkControl.Location = new System.Drawing.Point(332, 12);
            this.OkControl.Name = "OkControl";
            this.OkControl.Size = new System.Drawing.Size(75, 23);
            this.OkControl.TabIndex = 5;
            this.OkControl.Text = "Ok";
            this.OkControl.UseVisualStyleBackColor = true;
            // 
            // cancelControl
            // 
            this.cancelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelControl.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelControl.Location = new System.Drawing.Point(332, 42);
            this.cancelControl.Name = "cancelControl";
            this.cancelControl.Size = new System.Drawing.Size(75, 23);
            this.cancelControl.TabIndex = 6;
            this.cancelControl.Text = "Cancel";
            this.cancelControl.UseVisualStyleBackColor = true;
            // 
            // vsDropAssistPopupControl1
            // 
            this.vsDropAssistPopupControl1.Location = new System.Drawing.Point(0, 1);
            this.vsDropAssistPopupControl1.Name = "vsDropAssistPopupControl1";
            this.vsDropAssistPopupControl1.Size = new System.Drawing.Size(320, 131);
            this.vsDropAssistPopupControl1.TabIndex = 7;
            // 
            // DropActionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 133);
            this.ControlBox = false;
            this.Controls.Add(this.vsDropAssistPopupControl1);
            this.Controls.Add(this.cancelControl);
            this.Controls.Add(this.OkControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DropActionDialog";
            this.Text = "VSDropAsssist Settings";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button OkControl;
        private System.Windows.Forms.Button cancelControl;
        private VSDropAssistPopupControl vsDropAssistPopupControl1;
    }
}