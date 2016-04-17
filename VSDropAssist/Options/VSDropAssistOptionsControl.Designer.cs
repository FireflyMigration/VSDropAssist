
using VSDropAssist.Core.Entities;
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ViewControl = new System.Windows.Forms.Button();
            this.vsDropAssistList1 = new VSDropAssist.Settings.VSDropAssistList();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.vsDropAssistList1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ViewControl);
            this.splitContainer1.Size = new System.Drawing.Size(690, 247);
            this.splitContainer1.SplitterDistance = 207;
            this.splitContainer1.TabIndex = 4;
            // 
            // ViewControl
            // 
            this.ViewControl.Location = new System.Drawing.Point(0, 3);
            this.ViewControl.Name = "ViewControl";
            this.ViewControl.Size = new System.Drawing.Size(75, 23);
            this.ViewControl.TabIndex = 4;
            this.ViewControl.Text = "View";
            this.ViewControl.UseVisualStyleBackColor = true;
            this.ViewControl.Click += new System.EventHandler(this.ViewControl_Click);
            // 
            // vsDropAssistList1
            // 
            this.vsDropAssistList1.Data = null;
            this.vsDropAssistList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vsDropAssistList1.Location = new System.Drawing.Point(0, 0);
            this.vsDropAssistList1.Name = "vsDropAssistList1";
            this.vsDropAssistList1.Size = new System.Drawing.Size(690, 207);
            this.vsDropAssistList1.TabIndex = 0;
            // 
            // VSDropAssistOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "VSDropAssistOptionsControl";
            this.Size = new System.Drawing.Size(690, 247);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private VSDropAssistList vsDropAssistList1;
        private System.Windows.Forms.Button ViewControl;
    }
}
