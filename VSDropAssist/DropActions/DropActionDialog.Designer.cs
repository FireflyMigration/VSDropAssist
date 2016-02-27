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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter expression:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 122);
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
            this.exampleControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "Example", true));
            this.exampleControl.Location = new System.Drawing.Point(31, 135);
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
            this.prefixControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "FormatExpression", true));
            this.prefixControl.Location = new System.Drawing.Point(34, 66);
            this.prefixControl.Multiline = true;
            this.prefixControl.Name = "prefixControl";
            this.prefixControl.Size = new System.Drawing.Size(244, 53);
            this.prefixControl.TabIndex = 4;
          
            // 
            // OkControl
            // 
            this.OkControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkControl.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkControl.Location = new System.Drawing.Point(285, 12);
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
            this.cancelControl.Location = new System.Drawing.Point(285, 42);
            this.cancelControl.Name = "cancelControl";
            this.cancelControl.Size = new System.Drawing.Size(75, 23);
            this.cancelControl.TabIndex = 6;
            this.cancelControl.Text = "Cancel";
            this.cancelControl.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "VariableName", true));
            this.textBox1.Location = new System.Drawing.Point(34, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 20);
            this.textBox1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Enter variable name:";
            // 
            // bindingSource1
            // 
            this.bindingSource1.AllowNew = false;
            this.bindingSource1.DataSource = typeof(VSDropAssist.DropActions.Settings);
            // 
            // DropActionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 205);
            this.ControlBox = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
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
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}