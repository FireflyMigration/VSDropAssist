namespace VSDropAssist.Settings.TestHost
{
    partial class frmTestPopup
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
            this.vsDropAssistPopupControl1 = new VSDropAssist.Settings.VSDropAssistPopupControl();
            this.saveControl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // vsDropAssistPopupControl1
            // 
            this.vsDropAssistPopupControl1.Location = new System.Drawing.Point(1, 0);
            this.vsDropAssistPopupControl1.Name = "vsDropAssistPopupControl1";
            this.vsDropAssistPopupControl1.Size = new System.Drawing.Size(781, 432);
            this.vsDropAssistPopupControl1.TabIndex = 0;
            this.vsDropAssistPopupControl1.Load += new System.EventHandler(this.vsDropAssistPopupControl1_Load);
            // 
            // saveControl
            // 
            this.saveControl.Location = new System.Drawing.Point(800, 25);
            this.saveControl.Name = "saveControl";
            this.saveControl.Size = new System.Drawing.Size(75, 23);
            this.saveControl.TabIndex = 1;
            this.saveControl.Text = "Save";
            this.saveControl.UseVisualStyleBackColor = true;
            this.saveControl.Click += new System.EventHandler(this.saveControl_Click);
            // 
            // frmTestPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 456);
            this.Controls.Add(this.saveControl);
            this.Controls.Add(this.vsDropAssistPopupControl1);
            this.Name = "frmTestPopup";
            this.Text = "frmTestPopup";
            this.Load += new System.EventHandler(this.frmTestPopup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VSDropAssistPopupControl vsDropAssistPopupControl1;
        private System.Windows.Forms.Button saveControl;
    }
}