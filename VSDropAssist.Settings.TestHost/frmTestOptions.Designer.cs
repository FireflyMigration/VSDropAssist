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
            this.vsDropAssistList1 = new VSDropAssist.Settings.VSDropAssistList();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.editControl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vsDropAssistList1
            // 
            this.vsDropAssistList1.Data = null;
            this.vsDropAssistList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsDropAssistList1.Location = new System.Drawing.Point(0, 0);
            this.vsDropAssistList1.Name = "vsDropAssistList1";
            this.vsDropAssistList1.Size = new System.Drawing.Size(971, 518);
            this.vsDropAssistList1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.editControl);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.vsDropAssistList1);
            this.splitContainer1.Size = new System.Drawing.Size(971, 600);
            this.splitContainer1.SplitterDistance = 78;
            this.splitContainer1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // editControl
            // 
            this.editControl.Location = new System.Drawing.Point(136, 20);
            this.editControl.Name = "editControl";
            this.editControl.Size = new System.Drawing.Size(75, 23);
            this.editControl.TabIndex = 1;
            this.editControl.Text = "Edit";
            this.editControl.UseVisualStyleBackColor = true;
            this.editControl.Click += new System.EventHandler(this.editControl_Click);
            // 
            // frmTestOptions
            // 
            this.ClientSize = new System.Drawing.Size(971, 600);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmTestOptions";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.Button SaveControl;
        private System.Windows.Forms.Button LoadControl;
        private VSDropAssistList vsDropAssistList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button editControl;
    }
}

