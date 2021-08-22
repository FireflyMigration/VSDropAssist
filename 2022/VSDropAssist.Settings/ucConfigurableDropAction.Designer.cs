
namespace VSDropAssist.Settings
{
    partial class ucConfigurableDropAction
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
            this.bsConfiguration = new System.Windows.Forms.BindingSource(this.components);
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.NameControl = new System.Windows.Forms.Label();
            this.DescriptionControl = new System.Windows.Forms.Label();
            this.PressedKeysControl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsConfiguration)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsConfiguration
            // 
            this.bsConfiguration.DataSource = typeof(VSDropAssist.IDropActionConfiguration);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsConfiguration, "SupportsClasses", true));
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(36, 15);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(62, 17);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Classes";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsConfiguration, "SupportsMembers", true));
            this.checkBox5.Enabled = false;
            this.checkBox5.Location = new System.Drawing.Point(141, 15);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(69, 17);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "Members";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsConfiguration, "SupportsDroppingIntoMethod", true));
            this.checkBox6.Enabled = false;
            this.checkBox6.Location = new System.Drawing.Point(147, 19);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(103, 17);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "... into a Method";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsConfiguration, "SupportsDroppingIntoClass", true));
            this.checkBox7.Enabled = false;
            this.checkBox7.Location = new System.Drawing.Point(42, 19);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(92, 17);
            this.checkBox7.TabIndex = 6;
            this.checkBox7.Text = "... into a Class";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Location = new System.Drawing.Point(142, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 38);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Things you can drag";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox6);
            this.groupBox3.Controls.Add(this.checkBox7);
            this.groupBox3.Location = new System.Drawing.Point(136, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(288, 42);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Where you can drop them";
            // 
            // NameControl
            // 
            this.NameControl.AutoSize = true;
            this.NameControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameControl.Location = new System.Drawing.Point(19, 16);
            this.NameControl.Name = "NameControl";
            this.NameControl.Size = new System.Drawing.Size(39, 13);
            this.NameControl.TabIndex = 9;
            this.NameControl.Text = "Name";
            // 
            // DescriptionControl
            // 
            this.DescriptionControl.AutoSize = true;
            this.DescriptionControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionControl.Location = new System.Drawing.Point(19, 39);
            this.DescriptionControl.Name = "DescriptionControl";
            this.DescriptionControl.Size = new System.Drawing.Size(60, 13);
            this.DescriptionControl.TabIndex = 10;
            this.DescriptionControl.Text = "Description";
            // 
            // PressedKeysControl
            // 
            this.PressedKeysControl.AutoSize = true;
            this.PressedKeysControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PressedKeysControl.Location = new System.Drawing.Point(17, 62);
            this.PressedKeysControl.Name = "PressedKeysControl";
            this.PressedKeysControl.Size = new System.Drawing.Size(64, 25);
            this.PressedKeysControl.TabIndex = 11;
            this.PressedKeysControl.Text = "label1";
            // 
            // ucConfigurableDropAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.PressedKeysControl);
            this.Controls.Add(this.DescriptionControl);
            this.Controls.Add(this.NameControl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "ucConfigurableDropAction";
            this.Size = new System.Drawing.Size(555, 155);
            ((System.ComponentModel.ISupportInitialize)(this.bsConfiguration)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsConfiguration;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label NameControl;
        private System.Windows.Forms.Label DescriptionControl;
        private System.Windows.Forms.Label PressedKeysControl;
    }
}
