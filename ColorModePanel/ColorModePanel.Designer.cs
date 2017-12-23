namespace ColorModePanelControl
{
    partial class ColorModePanel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colorSetChangeBtn = new System.Windows.Forms.Button();
            this.setColor6 = new System.Windows.Forms.Panel();
            this.setColor5 = new System.Windows.Forms.Panel();
            this.setColor4 = new System.Windows.Forms.Panel();
            this.setColor3 = new System.Windows.Forms.Panel();
            this.setColor2 = new System.Windows.Forms.Panel();
            this.setColor1 = new System.Windows.Forms.Panel();
            this.noneRadioButton = new System.Windows.Forms.RadioButton();
            this.contRadioButton = new System.Windows.Forms.RadioButton();
            this.discreteRadioButton = new System.Windows.Forms.RadioButton();
            this.colorSetDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.colorSetChangeBtn);
            this.groupBox1.Controls.Add(this.setColor6);
            this.groupBox1.Controls.Add(this.setColor5);
            this.groupBox1.Controls.Add(this.setColor4);
            this.groupBox1.Controls.Add(this.setColor3);
            this.groupBox1.Controls.Add(this.setColor2);
            this.groupBox1.Controls.Add(this.setColor1);
            this.groupBox1.Controls.Add(this.noneRadioButton);
            this.groupBox1.Controls.Add(this.contRadioButton);
            this.groupBox1.Controls.Add(this.discreteRadioButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 137);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color Mode";
            // 
            // colorSetChangeBtn
            // 
            this.colorSetChangeBtn.Location = new System.Drawing.Point(9, 100);
            this.colorSetChangeBtn.Name = "colorSetChangeBtn";
            this.colorSetChangeBtn.Size = new System.Drawing.Size(102, 31);
            this.colorSetChangeBtn.TabIndex = 5;
            this.colorSetChangeBtn.Text = "Change Set";
            this.colorSetChangeBtn.UseVisualStyleBackColor = true;
            this.colorSetChangeBtn.Click += new System.EventHandler(this.colorSetChangeBtn_Click);
            // 
            // setColor6
            // 
            this.setColor6.Location = new System.Drawing.Point(81, 59);
            this.setColor6.Name = "setColor6";
            this.setColor6.Size = new System.Drawing.Size(30, 30);
            this.setColor6.TabIndex = 2;
            this.setColor6.Tag = "6";
            this.setColor6.Click += new System.EventHandler(this.ChangeSetColor);
            // 
            // setColor5
            // 
            this.setColor5.Location = new System.Drawing.Point(81, 23);
            this.setColor5.Name = "setColor5";
            this.setColor5.Size = new System.Drawing.Size(30, 30);
            this.setColor5.TabIndex = 2;
            this.setColor5.Tag = "5";
            this.setColor5.Click += new System.EventHandler(this.ChangeSetColor);
            // 
            // setColor4
            // 
            this.setColor4.Location = new System.Drawing.Point(45, 59);
            this.setColor4.Name = "setColor4";
            this.setColor4.Size = new System.Drawing.Size(30, 30);
            this.setColor4.TabIndex = 2;
            this.setColor4.Tag = "4";
            this.setColor4.Click += new System.EventHandler(this.ChangeSetColor);
            // 
            // setColor3
            // 
            this.setColor3.Location = new System.Drawing.Point(45, 23);
            this.setColor3.Name = "setColor3";
            this.setColor3.Size = new System.Drawing.Size(30, 30);
            this.setColor3.TabIndex = 2;
            this.setColor3.Tag = "3";
            this.setColor3.Click += new System.EventHandler(this.ChangeSetColor);
            // 
            // setColor2
            // 
            this.setColor2.Location = new System.Drawing.Point(9, 59);
            this.setColor2.Name = "setColor2";
            this.setColor2.Size = new System.Drawing.Size(30, 30);
            this.setColor2.TabIndex = 2;
            this.setColor2.Tag = "2";
            this.setColor2.Click += new System.EventHandler(this.ChangeSetColor);
            // 
            // setColor1
            // 
            this.setColor1.Location = new System.Drawing.Point(9, 23);
            this.setColor1.Name = "setColor1";
            this.setColor1.Size = new System.Drawing.Size(30, 30);
            this.setColor1.TabIndex = 2;
            this.setColor1.Tag = "1";
            this.setColor1.Click += new System.EventHandler(this.ChangeSetColor);
            // 
            // noneRadioButton
            // 
            this.noneRadioButton.AutoSize = true;
            this.noneRadioButton.Location = new System.Drawing.Point(117, 96);
            this.noneRadioButton.Name = "noneRadioButton";
            this.noneRadioButton.Size = new System.Drawing.Size(63, 21);
            this.noneRadioButton.TabIndex = 0;
            this.noneRadioButton.TabStop = true;
            this.noneRadioButton.Tag = "2";
            this.noneRadioButton.Text = "None";
            this.noneRadioButton.UseVisualStyleBackColor = true;
            this.noneRadioButton.CheckedChanged += new System.EventHandler(this.SelectColorFunction);
            // 
            // contRadioButton
            // 
            this.contRadioButton.AutoSize = true;
            this.contRadioButton.Location = new System.Drawing.Point(117, 59);
            this.contRadioButton.Name = "contRadioButton";
            this.contRadioButton.Size = new System.Drawing.Size(92, 21);
            this.contRadioButton.TabIndex = 0;
            this.contRadioButton.TabStop = true;
            this.contRadioButton.Tag = "1";
            this.contRadioButton.Text = "Continous";
            this.contRadioButton.UseVisualStyleBackColor = true;
            this.contRadioButton.CheckedChanged += new System.EventHandler(this.SelectColorFunction);
            // 
            // discreteRadioButton
            // 
            this.discreteRadioButton.AutoSize = true;
            this.discreteRadioButton.Checked = true;
            this.discreteRadioButton.Location = new System.Drawing.Point(117, 22);
            this.discreteRadioButton.Name = "discreteRadioButton";
            this.discreteRadioButton.Size = new System.Drawing.Size(81, 21);
            this.discreteRadioButton.TabIndex = 0;
            this.discreteRadioButton.TabStop = true;
            this.discreteRadioButton.Tag = "0";
            this.discreteRadioButton.Text = "Discrete";
            this.discreteRadioButton.UseVisualStyleBackColor = true;
            this.discreteRadioButton.CheckedChanged += new System.EventHandler(this.SelectColorFunction);
            // 
            // ColorModePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(387, 266);
            this.Name = "ColorModePanel";
            this.Size = new System.Drawing.Size(212, 137);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel setColor6;
        private System.Windows.Forms.Panel setColor5;
        private System.Windows.Forms.Panel setColor4;
        private System.Windows.Forms.Panel setColor3;
        private System.Windows.Forms.Panel setColor2;
        private System.Windows.Forms.Panel setColor1;
        private System.Windows.Forms.RadioButton noneRadioButton;
        private System.Windows.Forms.RadioButton contRadioButton;
        private System.Windows.Forms.RadioButton discreteRadioButton;
        private System.Windows.Forms.ColorDialog colorSetDialog;
        private System.Windows.Forms.Button colorSetChangeBtn;
    }
}
