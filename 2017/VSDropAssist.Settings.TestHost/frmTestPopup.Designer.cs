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
            this.SuspendLayout();
            // 
            // vsDropAssistPopupControl1
            // 
            this.vsDropAssistPopupControl1.Location = new System.Drawing.Point(3, 28);
            this.vsDropAssistPopupControl1.Name = "vsDropAssistPopupControl1";
            this.vsDropAssistPopupControl1.Size = new System.Drawing.Size(427, 205);
            this.vsDropAssistPopupControl1.TabIndex = 0;
            this.vsDropAssistPopupControl1.Load += new System.EventHandler(this.vsDropAssistPopupControl1_Load);
            // 
            // frmTestPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 261);
            this.Controls.Add(this.vsDropAssistPopupControl1);
            this.Name = "frmTestPopup";
            this.Text = "frmTestPopup";
            this.Load += new System.EventHandler(this.frmTestPopup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VSDropAssistPopupControl vsDropAssistPopupControl1;
    }
}