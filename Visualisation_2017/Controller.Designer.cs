namespace Visualisation_2017
{
    partial class Controller
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
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.meshInfoTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.resetTransformationsBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rotationAxisComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.fileLoadBtn = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.meshDataListBox = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.renderModeComboBox = new System.Windows.Forms.ComboBox();
            this.colorModePanel1 = new ColorModePanelControl.ColorModePanel();
            this.toggleModelBodyRenderCheckbox = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.calculateIsoSurfacesButton = new System.Windows.Forms.Button();
            this.isoSurfacesCountNumbericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.toggleIsoSurfacesRenderCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.calculateLineContoursButton = new System.Windows.Forms.Button();
            this.lineContoursCountNumberic = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.contourStyleComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toggleLineContoursCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.glHostPanel = new OpenGlHostControl.OpenGlHostPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.isoSurfacesCountNumbericUpDown)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineContoursCountNumberic)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "file";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(648, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.7153F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.2847F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(281, 665);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.meshInfoTextBox);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox6.Location = new System.Drawing.Point(3, 565);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(275, 97);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Mesh Info";
            // 
            // meshInfoTextBox
            // 
            this.meshInfoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshInfoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meshInfoTextBox.Location = new System.Drawing.Point(3, 21);
            this.meshInfoTextBox.Multiline = true;
            this.meshInfoTextBox.Name = "meshInfoTextBox";
            this.meshInfoTextBox.ReadOnly = true;
            this.meshInfoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.meshInfoTextBox.Size = new System.Drawing.Size(269, 73);
            this.meshInfoTextBox.TabIndex = 0;
            this.meshInfoTextBox.Text = "\r\nVertices: 203";
            this.meshInfoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(275, 442);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.resetTransformationsBtn);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(267, 413);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mesh";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // resetTransformationsBtn
            // 
            this.resetTransformationsBtn.Location = new System.Drawing.Point(6, 356);
            this.resetTransformationsBtn.Name = "resetTransformationsBtn";
            this.resetTransformationsBtn.Size = new System.Drawing.Size(251, 36);
            this.resetTransformationsBtn.TabIndex = 4;
            this.resetTransformationsBtn.Text = "Reset";
            this.resetTransformationsBtn.UseVisualStyleBackColor = true;
            this.resetTransformationsBtn.Click += new System.EventHandler(this.ResetTransformationsBtnClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.numericUpDown2);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rotationAxisComboBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 199);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transformations";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(145, 48);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 21);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Animate";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.ToggleAnimationCheckBoxCheckedChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(6, 165);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(246, 22);
            this.numericUpDown2.TabIndex = 2;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.ScaleFactorNumbericValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(6, 106);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(246, 22);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.TranslationFactorNumericValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Scale Factor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Translation Factor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rotation Axis";
            // 
            // rotationAxisComboBox
            // 
            this.rotationAxisComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rotationAxisComboBox.FormattingEnabled = true;
            this.rotationAxisComboBox.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.rotationAxisComboBox.Location = new System.Drawing.Point(6, 48);
            this.rotationAxisComboBox.Name = "rotationAxisComboBox";
            this.rotationAxisComboBox.Size = new System.Drawing.Size(120, 24);
            this.rotationAxisComboBox.TabIndex = 0;
            this.rotationAxisComboBox.SelectedIndexChanged += new System.EventHandler(this.RotationAxisComboBoxSelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filePathTextBox);
            this.groupBox1.Controls.Add(this.fileLoadBtn);
            this.groupBox1.Controls.Add(this.openFileButton);
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 128);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mesh File";
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.filePathTextBox.Location = new System.Drawing.Point(3, 18);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.ReadOnly = true;
            this.filePathTextBox.Size = new System.Drawing.Size(252, 22);
            this.filePathTextBox.TabIndex = 1;
            // 
            // fileLoadBtn
            // 
            this.fileLoadBtn.Enabled = false;
            this.fileLoadBtn.Location = new System.Drawing.Point(0, 80);
            this.fileLoadBtn.Name = "fileLoadBtn";
            this.fileLoadBtn.Size = new System.Drawing.Size(255, 31);
            this.fileLoadBtn.TabIndex = 0;
            this.fileLoadBtn.Text = "Load";
            this.fileLoadBtn.UseVisualStyleBackColor = true;
            this.fileLoadBtn.Click += new System.EventHandler(this.FileLoadBtnClick);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(0, 45);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(255, 29);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Choose File";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.OpenFileButton1Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(267, 413);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rendering";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Controls.Add(this.groupBox5);
            this.flowLayoutPanel1.Controls.Add(this.colorModePanel1);
            this.flowLayoutPanel1.Controls.Add(this.toggleModelBodyRenderCheckbox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(261, 407);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.meshDataListBox);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(255, 164);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mesh Data";
            // 
            // meshDataListBox
            // 
            this.meshDataListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meshDataListBox.FormattingEnabled = true;
            this.meshDataListBox.ItemHeight = 16;
            this.meshDataListBox.Location = new System.Drawing.Point(3, 18);
            this.meshDataListBox.Name = "meshDataListBox";
            this.meshDataListBox.Size = new System.Drawing.Size(249, 143);
            this.meshDataListBox.TabIndex = 0;
            this.meshDataListBox.SelectedIndexChanged += new System.EventHandler(this.HandleMeshDataSelected);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.renderModeComboBox);
            this.groupBox5.Location = new System.Drawing.Point(3, 173);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(255, 49);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Render Mode";
            // 
            // renderModeComboBox
            // 
            this.renderModeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.renderModeComboBox.FormattingEnabled = true;
            this.renderModeComboBox.Items.AddRange(new object[] {
            "Filled",
            "Wire frame"});
            this.renderModeComboBox.Location = new System.Drawing.Point(3, 18);
            this.renderModeComboBox.Name = "renderModeComboBox";
            this.renderModeComboBox.Size = new System.Drawing.Size(249, 24);
            this.renderModeComboBox.TabIndex = 0;
            this.renderModeComboBox.SelectedIndexChanged += new System.EventHandler(this.RenderModeComboBoxSelectedIndexChanged);
            // 
            // colorModePanel1
            // 
            this.colorModePanel1.ColouringFunction = ColorUtilityPackage.ColouringFunction.Discrete;
            this.colorModePanel1.Location = new System.Drawing.Point(3, 228);
            this.colorModePanel1.MaximumSize = new System.Drawing.Size(387, 266);
            this.colorModePanel1.Name = "colorModePanel1";
            this.colorModePanel1.Size = new System.Drawing.Size(252, 137);
            this.colorModePanel1.TabIndex = 2;
            this.colorModePanel1.OnColorFunctionChanged += new ColorModePanelControl.ColorModePanel.OnColorFunctionChangedDelegate(this.ColorModePanel1_OnColorFunctionChanged);
            // 
            // toggleModelBodyRenderCheckbox
            // 
            this.toggleModelBodyRenderCheckbox.AutoSize = true;
            this.toggleModelBodyRenderCheckbox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toggleModelBodyRenderCheckbox.Location = new System.Drawing.Point(3, 371);
            this.toggleModelBodyRenderCheckbox.Name = "toggleModelBodyRenderCheckbox";
            this.toggleModelBodyRenderCheckbox.Size = new System.Drawing.Size(113, 21);
            this.toggleModelBodyRenderCheckbox.TabIndex = 4;
            this.toggleModelBodyRenderCheckbox.Text = "Render Body";
            this.toggleModelBodyRenderCheckbox.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toggleModelBodyRenderCheckbox.UseVisualStyleBackColor = true;
            this.toggleModelBodyRenderCheckbox.CheckedChanged += new System.EventHandler(this.ToggleModelBodyRenderCheckbox_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox10);
            this.tabPage3.Controls.Add(this.groupBox9);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(267, 413);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Contouring";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.calculateIsoSurfacesButton);
            this.groupBox10.Controls.Add(this.isoSurfacesCountNumbericUpDown);
            this.groupBox10.Controls.Add(this.label7);
            this.groupBox10.Controls.Add(this.toggleIsoSurfacesRenderCheckbox);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox10.Location = new System.Drawing.Point(3, 232);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(261, 200);
            this.groupBox10.TabIndex = 4;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "IsoSurfaces";
            // 
            // calculateIsoSurfacesButton
            // 
            this.calculateIsoSurfacesButton.Location = new System.Drawing.Point(6, 124);
            this.calculateIsoSurfacesButton.Name = "calculateIsoSurfacesButton";
            this.calculateIsoSurfacesButton.Size = new System.Drawing.Size(247, 41);
            this.calculateIsoSurfacesButton.TabIndex = 13;
            this.calculateIsoSurfacesButton.Text = "Calculate";
            this.calculateIsoSurfacesButton.UseVisualStyleBackColor = true;
            this.calculateIsoSurfacesButton.Click += new System.EventHandler(this.CalculateIsoSurfacesButtonClick);
            // 
            // isoSurfacesCountNumbericUpDown
            // 
            this.isoSurfacesCountNumbericUpDown.Location = new System.Drawing.Point(9, 54);
            this.isoSurfacesCountNumbericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.isoSurfacesCountNumbericUpDown.Name = "isoSurfacesCountNumbericUpDown";
            this.isoSurfacesCountNumbericUpDown.Size = new System.Drawing.Size(245, 22);
            this.isoSurfacesCountNumbericUpDown.TabIndex = 11;
            this.isoSurfacesCountNumbericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Surfaces Count";
            // 
            // toggleIsoSurfacesRenderCheckbox
            // 
            this.toggleIsoSurfacesRenderCheckbox.AutoSize = true;
            this.toggleIsoSurfacesRenderCheckbox.Location = new System.Drawing.Point(10, 80);
            this.toggleIsoSurfacesRenderCheckbox.Name = "toggleIsoSurfacesRenderCheckbox";
            this.toggleIsoSurfacesRenderCheckbox.Size = new System.Drawing.Size(130, 21);
            this.toggleIsoSurfacesRenderCheckbox.TabIndex = 12;
            this.toggleIsoSurfacesRenderCheckbox.Text = "Render Surface";
            this.toggleIsoSurfacesRenderCheckbox.UseVisualStyleBackColor = true;
            this.toggleIsoSurfacesRenderCheckbox.CheckedChanged += new System.EventHandler(this.ToggleIsoSurfacesRenderCheckbox_CheckedChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.calculateLineContoursButton);
            this.groupBox9.Controls.Add(this.lineContoursCountNumberic);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.contourStyleComboBox);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.toggleLineContoursCheckBox);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox9.Location = new System.Drawing.Point(3, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(261, 229);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Contour Lines";
            // 
            // calculateLineContoursButton
            // 
            this.calculateLineContoursButton.Location = new System.Drawing.Point(3, 171);
            this.calculateLineContoursButton.Name = "calculateLineContoursButton";
            this.calculateLineContoursButton.Size = new System.Drawing.Size(247, 40);
            this.calculateLineContoursButton.TabIndex = 10;
            this.calculateLineContoursButton.Text = "Calculate";
            this.calculateLineContoursButton.UseVisualStyleBackColor = true;
            this.calculateLineContoursButton.Click += new System.EventHandler(this.CalculateLineContoursButton_Click);
            // 
            // lineContoursCountNumberic
            // 
            this.lineContoursCountNumberic.Location = new System.Drawing.Point(9, 96);
            this.lineContoursCountNumberic.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.lineContoursCountNumberic.Name = "lineContoursCountNumberic";
            this.lineContoursCountNumberic.Size = new System.Drawing.Size(245, 22);
            this.lineContoursCountNumberic.TabIndex = 8;
            this.lineContoursCountNumberic.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Number";
            // 
            // contourStyleComboBox
            // 
            this.contourStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.contourStyleComboBox.Enabled = false;
            this.contourStyleComboBox.FormattingEnabled = true;
            this.contourStyleComboBox.Items.AddRange(new object[] {
            "Lines",
            "Flooded"});
            this.contourStyleComboBox.Location = new System.Drawing.Point(5, 44);
            this.contourStyleComboBox.Name = "contourStyleComboBox";
            this.contourStyleComboBox.Size = new System.Drawing.Size(251, 24);
            this.contourStyleComboBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contour Style";
            // 
            // toggleLineContoursCheckBox
            // 
            this.toggleLineContoursCheckBox.AutoSize = true;
            this.toggleLineContoursCheckBox.Location = new System.Drawing.Point(5, 124);
            this.toggleLineContoursCheckBox.Name = "toggleLineContoursCheckBox";
            this.toggleLineContoursCheckBox.Size = new System.Drawing.Size(138, 21);
            this.toggleLineContoursCheckBox.TabIndex = 9;
            this.toggleLineContoursCheckBox.Text = "Render Contours";
            this.toggleLineContoursCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(3, 451);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 108);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Legend";
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(3, 21);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(269, 84);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "Move: Up | Down | Right | Left Arrows\r\n\r\nZoom In/Out: Page Down / Page Up\r\n\r\nScal" +
    "e On X +/- : X / C\r\nScale On Y +/-: Y / H\r\n\r\nRotate on Selected Axis: R";
            // 
            // animationTimer
            // 
            this.animationTimer.Tick += new System.EventHandler(this.AnimationTimerTick);
            // 
            // glHostPanel
            // 
            this.glHostPanel.AccumBits = ((byte)(0));
            this.glHostPanel.AutoCheckErrors = false;
            this.glHostPanel.AutoFinish = false;
            this.glHostPanel.AutoMakeCurrent = true;
            this.glHostPanel.AutoSwapBuffers = true;
            this.glHostPanel.BackColor = System.Drawing.Color.Black;
            this.glHostPanel.ColorBits = ((byte)(32));
            this.glHostPanel.DepthBits = ((byte)(16));
            this.glHostPanel.HookRenderOnPaintEvent = true;
            this.glHostPanel.Location = new System.Drawing.Point(9, 12);
            this.glHostPanel.Name = "glHostPanel";
            this.glHostPanel.RenderIsoSurfaces = false;
            this.glHostPanel.ScaleFactor = 1D;
            this.glHostPanel.Size = new System.Drawing.Size(633, 641);
            this.glHostPanel.StencilBits = ((byte)(0));
            this.glHostPanel.TabIndex = 2;
            this.glHostPanel.TranslationFactor = 1D;
            this.glHostPanel.OnSelectedDataChanged += new OpenGlHostControl.OpenGlHostPanel.OnSelectedDataChangedDelegate(this.glHostPanel_OnSelectedDataChanged);
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 665);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.glHostPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Controller";
            this.Text = "Controller";
            this.Load += new System.EventHandler(this.Controller_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.isoSurfacesCountNumbericUpDown)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineContoursCountNumberic)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private OpenGlHostControl.OpenGlHostPanel glHostPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox rotationAxisComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button fileLoadBtn;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox meshInfoTextBox;
        private System.Windows.Forms.Button resetTransformationsBtn;
        private System.Windows.Forms.GroupBox groupBox5;
        private ColorModePanelControl.ColorModePanel colorModePanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox meshDataListBox;
        private System.Windows.Forms.ComboBox renderModeComboBox;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button calculateIsoSurfacesButton;
        private System.Windows.Forms.NumericUpDown isoSurfacesCountNumbericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox toggleIsoSurfacesRenderCheckbox;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button calculateLineContoursButton;
        private System.Windows.Forms.NumericUpDown lineContoursCountNumberic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox contourStyleComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox toggleLineContoursCheckBox;
        private System.Windows.Forms.CheckBox toggleModelBodyRenderCheckbox;
    }
}