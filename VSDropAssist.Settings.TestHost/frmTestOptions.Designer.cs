namespace VSDropAssist.Settings.TestHost
{
    partial class frmTestOptions
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
            this.vsDropAssistOptionsControl1 = new VSDropAssist.Settings.VSDropAssistOptionsList();
            this.SaveControl = new System.Windows.Forms.Button();
            this.LoadControl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // vsDropAssistOptionsControl1
            // 
            this.vsDropAssistOptionsControl1.Location = new System.Drawing.Point(21, 12);
            this.vsDropAssistOptionsControl1.Name = "vsDropAssistOptionsControl1";
            this.vsDropAssistOptionsControl1.Size = new System.Drawing.Size(690, 249);
            this.vsDropAssistOptionsControl1.TabIndex = 0;
            // 
            // SaveControl
            // 
            this.SaveControl.Location = new System.Drawing.Point(784, 41);
            this.SaveControl.Name = "SaveControl";
            this.SaveControl.Size = new System.Drawing.Size(75, 23);
            this.SaveControl.TabIndex = 1;
            this.SaveControl.Text = "Save";
            this.SaveControl.UseVisualStyleBackColor = true;
            this.SaveControl.Click += new System.EventHandler(this.SaveControl_Click);
            // 
            // LoadControl
            // 
            this.LoadControl.Location = new System.Drawing.Point(784, 70);
            this.LoadControl.Name = "LoadControl";
            this.LoadControl.Size = new System.Drawing.Size(75, 23);
            this.LoadControl.TabIndex = 1;
            this.LoadControl.Text = "Load";
            this.LoadControl.UseVisualStyleBackColor = true;
            this.LoadControl.Click += new System.EventHandler(this.SaveControl_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 341);
            this.Controls.Add(this.LoadControl);
            this.Controls.Add(this.SaveControl);
            this.Controls.Add(this.vsDropAssistOptionsControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VSDropAssistOptionsList vsDropAssistOptionsControl1;
        private System.Windows.Forms.Button SaveControl;
        private System.Windows.Forms.Button LoadControl;
    }
}

