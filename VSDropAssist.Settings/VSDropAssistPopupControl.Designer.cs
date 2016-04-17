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
            System.Windows.Forms.Label delimiterLabel;
            System.Windows.Forms.Label formatExpressionLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label tokenToSelectAfterDropLabel;
            System.Windows.Forms.Label prefixLabel;
            System.Windows.Forms.Label suffixLabel;
            this.settingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.altMustBeDownCheckBox = new System.Windows.Forms.CheckBox();
            this.controlMustBeDownCheckBox = new System.Windows.Forms.CheckBox();
            this.delimiterTextBox = new System.Windows.Forms.TextBox();
            this.formatExpressionTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.selectAfterDropCheckBox = new System.Windows.Forms.CheckBox();
            this.selectFirstLineOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.shiftMustBeDownCheckBox = new System.Windows.Forms.CheckBox();
            this.supportsClassesCheckBox = new System.Windows.Forms.CheckBox();
            this.supportsDroppingIntoClassCheckBox = new System.Windows.Forms.CheckBox();
            this.supportsDroppingIntoMethodCheckBox = new System.Windows.Forms.CheckBox();
            this.supportsMembersCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tokenToSelectAfterDropComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.prefixTextBox = new System.Windows.Forms.TextBox();
            this.suffixTextBox = new System.Windows.Forms.TextBox();
            delimiterLabel = new System.Windows.Forms.Label();
            formatExpressionLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            tokenToSelectAfterDropLabel = new System.Windows.Forms.Label();
            prefixLabel = new System.Windows.Forms.Label();
            suffixLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // delimiterLabel
            // 
            delimiterLabel.AutoSize = true;
            delimiterLabel.Location = new System.Drawing.Point(8, 141);
            delimiterLabel.Name = "delimiterLabel";
            delimiterLabel.Size = new System.Drawing.Size(50, 13);
            delimiterLabel.TabIndex = 4;
            delimiterLabel.Text = "Delimiter:";
            // 
            // formatExpressionLabel
            // 
            formatExpressionLabel.AutoSize = true;
            formatExpressionLabel.Location = new System.Drawing.Point(2, 225);
            formatExpressionLabel.Name = "formatExpressionLabel";
            formatExpressionLabel.Size = new System.Drawing.Size(54, 13);
            formatExpressionLabel.TabIndex = 6;
            formatExpressionLabel.Text = "Template:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(2, 8);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 8;
            nameLabel.Text = "Name:";
            // 
            // tokenToSelectAfterDropLabel
            // 
            tokenToSelectAfterDropLabel.AutoSize = true;
            tokenToSelectAfterDropLabel.Location = new System.Drawing.Point(17, 57);
            tokenToSelectAfterDropLabel.Name = "tokenToSelectAfterDropLabel";
            tokenToSelectAfterDropLabel.Size = new System.Drawing.Size(141, 13);
            tokenToSelectAfterDropLabel.TabIndex = 27;
            tokenToSelectAfterDropLabel.Text = "Token To Select After Drop:";
            // 
            // settingsBindingSource
            // 
            this.settingsBindingSource.DataSource = typeof(VSDropAssist.Settings.DropActionConfiguration);
            // 
            // altMustBeDownCheckBox
            // 
            this.altMustBeDownCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.settingsBindingSource, "AltMustBeDown", true));
            this.altMustBeDownCheckBox.Location = new System.Drawing.Point(205, 19);
            this.altMustBeDownCheckBox.Name = "altMustBeDownCheckBox";
            this.altMustBeDownCheckBox.Size = new System.Drawing.Size(104, 24);
            this.altMustBeDownCheckBox.TabIndex = 1;
            this.altMustBeDownCheckBox.Text = "Alt";
            this.altMustBeDownCheckBox.UseVisualStyleBackColor = true;
            // 
            // controlMustBeDownCheckBox
            // 
            this.controlMustBeDownCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.settingsBindingSource, "ControlMustBeDown", true));
            this.controlMustBeDownCheckBox.Location = new System.Drawing.Point(17, 49);
            this.controlMustBeDownCheckBox.Name = "controlMustBeDownCheckBox";
            this.controlMustBeDownCheckBox.Size = new System.Drawing.Size(104, 24);
            this.controlMustBeDownCheckBox.TabIndex = 2;
            this.controlMustBeDownCheckBox.Text = "Control";
            this.controlMustBeDownCheckBox.UseVisualStyleBackColor = true;
            // 
            // delimiterTextBox
            // 
            this.delimiterTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsBindingSource, "Delimiter", true));
            this.delimiterTextBox.Location = new System.Drawing.Point(130, 138);
            this.delimiterTextBox.Name = "delimiterTextBox";
            this.delimiterTextBox.Size = new System.Drawing.Size(168, 20);
            this.delimiterTextBox.TabIndex = 1;
            this.toolTip1.SetToolTip(this.delimiterTextBox, "Text to insert between dropped items");
            // 
            // formatExpressionTextBox
            // 
            this.formatExpressionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsBindingSource, "FormatExpression", true));
            this.formatExpressionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formatExpressionTextBox.Location = new System.Drawing.Point(0, 0);
            this.formatExpressionTextBox.Multiline = true;
            this.formatExpressionTextBox.Name = "formatExpressionTextBox";
            this.formatExpressionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.formatExpressionTextBox.Size = new System.Drawing.Size(774, 183);
            this.formatExpressionTextBox.TabIndex = 0;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(67, 5);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(317, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // selectAfterDropCheckBox
            // 
            this.selectAfterDropCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.settingsBindingSource, "SelectAfterDrop", true));
            this.selectAfterDropCheckBox.Location = new System.Drawing.Point(20, 19);
            this.selectAfterDropCheckBox.Name = "selectAfterDropCheckBox";
            this.selectAfterDropCheckBox.Size = new System.Drawing.Size(102, 24);
            this.selectAfterDropCheckBox.TabIndex = 0;
            this.selectAfterDropCheckBox.Text = "Select text";
            this.selectAfterDropCheckBox.UseVisualStyleBackColor = true;
            // 
            // selectFirstLineOnlyCheckBox
            // 
            this.selectFirstLineOnlyCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.settingsBindingSource, "SelectFirstLineOnly", true));
            this.selectFirstLineOnlyCheckBox.Location = new System.Drawing.Point(149, 19);
            this.selectFirstLineOnlyCheckBox.Name = "selectFirstLineOnlyCheckBox";
            this.selectFirstLineOnlyCheckBox.Size = new System.Drawing.Size(121, 24);
            this.selectFirstLineOnlyCheckBox.TabIndex = 1;
            this.selectFirstLineOnlyCheckBox.Text = "first line only";
            this.selectFirstLineOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // shiftMustBeDownCheckBox
            // 
            this.shiftMustBeDownCheckBox.Checked = true;
            this.shiftMustBeDownCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shiftMustBeDownCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.settingsBindingSource, "ShiftMustBeDown", true));
            this.shiftMustBeDownCheckBox.Location = new System.Drawing.Point(17, 19);
            this.shiftMustBeDownCheckBox.Name = "shiftMustBeDownCheckBox";
            this.shiftMustBeDownCheckBox.Size = new System.Drawing.Size(104, 24);
            this.shiftMustBeDownCheckBox.TabIndex = 0;
            this.shiftMustBeDownCheckBox.Text = "Shift";
            this.shiftMustBeDownCheckBox.UseVisualStyleBackColor = true;
            // 
            // supportsClassesCheckBox
            // 
            this.supportsClassesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.settingsBindingSource, "SupportsClasses", true));
            this.supportsClassesCheckBox.Location = new System.Drawing.Point(18, 49);
            this.supportsClassesCheckBox.Name = "supportsClassesCheckBox";
            this.supportsClassesCheckBox.Size = new System.Drawing.Size(104, 24);
            this.supportsClassesCheckBox.TabIndex = 1;
            this.supportsClassesCheckBox.Text = "Classes";
            this.supportsClassesCheckBox.UseVisualStyleBackColor = true;
            // 
            // supportsDroppingIntoClassCheckBox
            // 
            this.supportsDroppingIntoClassCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.settingsBindingSource, "SupportsDroppingIntoClass", true));
            this.supportsDroppingIntoClassCheckBox.Location = new System.Drawing.Point(6, 19);
            this.supportsDroppingIntoClassCheckBox.Name = "supportsDroppingIntoClassCheckBox";
            this.supportsDroppingIntoClassCheckBox.Size = new System.Drawing.Size(104, 24);
            this.supportsDroppingIntoClassCheckBox.TabIndex = 0;
            this.supportsDroppingIntoClassCheckBox.Text = "into a class";
            this.supportsDroppingIntoClassCheckBox.UseVisualStyleBackColor = true;
            // 
            // supportsDroppingIntoMethodCheckBox
            // 
            this.supportsDroppingIntoMethodCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.settingsBindingSource, "SupportsDroppingIntoMethod", true));
            this.supportsDroppingIntoMethodCheckBox.Location = new System.Drawing.Point(6, 49);
            this.supportsDroppingIntoMethodCheckBox.Name = "supportsDroppingIntoMethodCheckBox";
            this.supportsDroppingIntoMethodCheckBox.Size = new System.Drawing.Size(104, 24);
            this.supportsDroppingIntoMethodCheckBox.TabIndex = 1;
            this.supportsDroppingIntoMethodCheckBox.Text = "into a method";
            this.supportsDroppingIntoMethodCheckBox.UseVisualStyleBackColor = true;
            // 
            // supportsMembersCheckBox
            // 
            this.supportsMembersCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.settingsBindingSource, "SupportsMembers", true));
            this.supportsMembersCheckBox.Location = new System.Drawing.Point(18, 19);
            this.supportsMembersCheckBox.Name = "supportsMembersCheckBox";
            this.supportsMembersCheckBox.Size = new System.Drawing.Size(104, 24);
            this.supportsMembersCheckBox.TabIndex = 0;
            this.supportsMembersCheckBox.Text = "Members";
            this.supportsMembersCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.supportsMembersCheckBox);
            this.groupBox1.Controls.Add(this.supportsClassesCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(362, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 81);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available when the user selects";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.shiftMustBeDownCheckBox);
            this.groupBox2.Controls.Add(this.controlMustBeDownCheckBox);
            this.groupBox2.Controls.Add(this.altMustBeDownCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(5, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 81);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hotkeys the user must press";
            // 
            // tokenToSelectAfterDropComboBox
            // 
            this.tokenToSelectAfterDropComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsBindingSource, "TokenToSelectAfterDrop", true));
            this.tokenToSelectAfterDropComboBox.FormattingEnabled = true;
            this.tokenToSelectAfterDropComboBox.Location = new System.Drawing.Point(164, 54);
            this.tokenToSelectAfterDropComboBox.Name = "tokenToSelectAfterDropComboBox";
            this.tokenToSelectAfterDropComboBox.Size = new System.Drawing.Size(121, 21);
            this.tokenToSelectAfterDropComboBox.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.supportsDroppingIntoClassCheckBox);
            this.groupBox3.Controls.Add(this.supportsDroppingIntoMethodCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(562, 43);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 81);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Available when the user is dropping";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.selectAfterDropCheckBox);
            this.groupBox4.Controls.Add(this.selectFirstLineOnlyCheckBox);
            this.groupBox4.Controls.Add(this.tokenToSelectAfterDropComboBox);
            this.groupBox4.Controls.Add(tokenToSelectAfterDropLabel);
            this.groupBox4.Location = new System.Drawing.Point(362, 141);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(400, 87);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "After inserting code";
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
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(suffixLabel);
            this.splitContainer1.Panel1.Controls.Add(this.suffixTextBox);
            this.splitContainer1.Panel1.Controls.Add(prefixLabel);
            this.splitContainer1.Panel1.Controls.Add(this.prefixTextBox);
            this.splitContainer1.Panel1.Controls.Add(nameLabel);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.nameTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(formatExpressionLabel);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.delimiterTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(delimiterLabel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.formatExpressionTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(774, 434);
            this.splitContainer1.SplitterDistance = 247;
            this.splitContainer1.TabIndex = 31;
            // 
            // prefixLabel
            // 
            prefixLabel.AutoSize = true;
            prefixLabel.Location = new System.Drawing.Point(8, 168);
            prefixLabel.Name = "prefixLabel";
            prefixLabel.Size = new System.Drawing.Size(36, 13);
            prefixLabel.TabIndex = 30;
            prefixLabel.Text = "Prefix:";
            // 
            // prefixTextBox
            // 
            this.prefixTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsBindingSource, "Prefix", true));
            this.prefixTextBox.Location = new System.Drawing.Point(130, 165);
            this.prefixTextBox.Name = "prefixTextBox";
            this.prefixTextBox.Size = new System.Drawing.Size(100, 20);
            this.prefixTextBox.TabIndex = 31;
            this.toolTip1.SetToolTip(this.prefixTextBox, "Text to insert before each item");
            // 
            // suffixLabel
            // 
            suffixLabel.AutoSize = true;
            suffixLabel.Location = new System.Drawing.Point(8, 194);
            suffixLabel.Name = "suffixLabel";
            suffixLabel.Size = new System.Drawing.Size(36, 13);
            suffixLabel.TabIndex = 31;
            suffixLabel.Text = "Suffix:";
            // 
            // suffixTextBox
            // 
            this.suffixTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingsBindingSource, "Suffix", true));
            this.suffixTextBox.Location = new System.Drawing.Point(130, 191);
            this.suffixTextBox.Name = "suffixTextBox";
            this.suffixTextBox.Size = new System.Drawing.Size(100, 20);
            this.suffixTextBox.TabIndex = 32;
            this.toolTip1.SetToolTip(this.suffixTextBox, "Text to insert after the template for each item");
            // 
            // VSDropAssistPopupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "VSDropAssistPopupControl";
            this.Size = new System.Drawing.Size(774, 434);
            ((System.ComponentModel.ISupportInitialize)(this.settingsBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource settingsBindingSource;
        private System.Windows.Forms.CheckBox altMustBeDownCheckBox;
        private System.Windows.Forms.CheckBox controlMustBeDownCheckBox;
        private System.Windows.Forms.TextBox delimiterTextBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox formatExpressionTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.CheckBox selectAfterDropCheckBox;
        private System.Windows.Forms.CheckBox selectFirstLineOnlyCheckBox;
        private System.Windows.Forms.CheckBox shiftMustBeDownCheckBox;
        private System.Windows.Forms.CheckBox supportsClassesCheckBox;
        private System.Windows.Forms.CheckBox supportsDroppingIntoClassCheckBox;
        private System.Windows.Forms.CheckBox supportsDroppingIntoMethodCheckBox;
        private System.Windows.Forms.CheckBox supportsMembersCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox tokenToSelectAfterDropComboBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox suffixTextBox;
        private System.Windows.Forms.TextBox prefixTextBox;
    }
}
