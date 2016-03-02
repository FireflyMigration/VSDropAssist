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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.exampleControl = new System.Windows.Forms.Label();
            this.prefixControl = new System.Windows.Forms.TextBox();
            this.OkControl = new System.Windows.Forms.Button();
            this.cancelControl = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bsSettings = new System.Windows.Forms.BindingSource(this.components);
            this.settingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter expression:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Example:";
            // 
            // exampleControl
            // 
            this.exampleControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exampleControl.AutoSize = true;
            this.exampleControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSettings, "Example", true));
            this.exampleControl.Location = new System.Drawing.Point(31, 171);
            this.exampleControl.Name = "exampleControl";
            this.exampleControl.Size = new System.Drawing.Size(35, 13);
            this.exampleControl.TabIndex = 3;
            this.exampleControl.Text = "label4";
            // 
            // prefixControl
            // 
            this.prefixControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prefixControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSettings, "FormatExpression", true));
            this.prefixControl.Location = new System.Drawing.Point(34, 102);
            this.prefixControl.Multiline = true;
            this.prefixControl.Name = "prefixControl";
            this.prefixControl.Size = new System.Drawing.Size(366, 53);
            this.prefixControl.TabIndex = 4;
            // 
            // OkControl
            // 
            this.OkControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkControl.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkControl.Location = new System.Drawing.Point(407, 12);
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
            this.cancelControl.Location = new System.Drawing.Point(407, 42);
            this.cancelControl.Name = "cancelControl";
            this.cancelControl.Size = new System.Drawing.Size(75, 23);
            this.cancelControl.TabIndex = 6;
            this.cancelControl.Text = "Cancel";
            this.cancelControl.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSettings, "VariableName", true));
            this.textBox1.Location = new System.Drawing.Point(34, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 20);
            this.textBox1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Enter variable name:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(137, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Choose Format";
            // 
            // bsSettings
            // 
            this.bsSettings.AllowNew = false;
            this.bsSettings.DataSource = typeof(VSDropSettings);
            // 
            // settingsBindingSource
            // 
            this.settingsBindingSource.DataMember = "Settings";
            this.settingsBindingSource.DataSource = this.bsSettings;
            // 
            // DropActionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 205);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelControl);
            this.Controls.Add(this.OkControl);
            this.Controls.Add(this.prefixControl);
            this.Controls.Add(this.exampleControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DropActionDialog";
            this.Text = "VSDropAsssist Settings";
            ((System.ComponentModel.ISupportInitialize)(this.bsSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label exampleControl;
        private System.Windows.Forms.TextBox prefixControl;
        private System.Windows.Forms.Button OkControl;
        private System.Windows.Forms.Button cancelControl;
        private System.Windows.Forms.BindingSource bsSettings;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource settingsBindingSource;
    }
}