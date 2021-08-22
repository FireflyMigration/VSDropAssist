namespace VSDropAssist.Settings
{
    partial class VSDropAssistPopupControl
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
            this.OptionKeyControl = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.variableNameControl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FormatExpressionControl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ExampleControl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // OptionKeyControl
            // 
            this.OptionKeyControl.DataSource = this.bindingSource1;
            this.OptionKeyControl.DisplayMember = "Key";
            this.OptionKeyControl.FormattingEnabled = true;
            this.OptionKeyControl.Location = new System.Drawing.Point(119, 19);
            this.OptionKeyControl.Name = "OptionKeyControl";
            this.OptionKeyControl.Size = new System.Drawing.Size(180, 21);
            this.OptionKeyControl.TabIndex = 0;
            this.OptionKeyControl.ValueMember = "Key";
            this.OptionKeyControl.SelectedIndexChanged += new System.EventHandler(this.OptionKeyControl_SelectedIndexChanged);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Settings";
            this.bindingSource1.DataSource = typeof(VSDropAssist.Settings.VSDropSettings);
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select format:";
            // 
            // variableNameControl
            // 
            this.variableNameControl.Location = new System.Drawing.Point(119, 47);
            this.variableNameControl.Name = "variableNameControl";
            this.variableNameControl.Size = new System.Drawing.Size(180, 20);
            this.variableNameControl.TabIndex = 2;
            this.variableNameControl.TextChanged += new System.EventHandler(this.variableNameControl_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter variable name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Format expression:";
            // 
            // FormatExpressionControl
            // 
            this.FormatExpressionControl.AutoSize = true;
            this.FormatExpressionControl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource1, "FormatExpression", true));
            this.FormatExpressionControl.Location = new System.Drawing.Point(116, 79);
            this.FormatExpressionControl.Name = "FormatExpressionControl";
            this.FormatExpressionControl.Size = new System.Drawing.Size(46, 13);
            this.FormatExpressionControl.TabIndex = 4;
            this.FormatExpressionControl.Text = "{x} = {c}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Format expression:";
            // 
            // ExampleControl
            // 
            this.ExampleControl.AutoSize = true;
            this.ExampleControl.Location = new System.Drawing.Point(116, 102);
            this.ExampleControl.Name = "ExampleControl";
            this.ExampleControl.Size = new System.Drawing.Size(40, 13);
            this.ExampleControl.TabIndex = 4;
            this.ExampleControl.Text = "sample";
            // 
            // VSDropAssistPopupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExampleControl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FormatExpressionControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.variableNameControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OptionKeyControl);
            this.Name = "VSDropAssistPopupControl";
            this.Size = new System.Drawing.Size(476, 205);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox OptionKeyControl;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox variableNameControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label FormatExpressionControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ExampleControl;
    }
}
