using System;
using System.Windows.Forms;
using ColorModePanelControl;
using OpenGlHostControl;
using Visualization;
using ColorUtilityPackage;
using Visualization.Mathf;

namespace Visualisation_2017
{
    
    public partial class Controller : Form
    {
        private string meshFilePath;

        public Controller()
        {
            InitializeComponent();
            InitializeDefaults();
            

        }

        private void InitializeDefaults()
        {
            rotationAxisComboBox.SelectedIndex = 0;
            renderModeComboBox.SelectedIndex = 0;
        }

        private void OpenFileButton1Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                meshFilePath = fileDialog.FileName;
                fileLoadBtn.Enabled = true;
                filePathTextBox.Text = meshFilePath;
            }
        }

        private void fielLoadBtn_Click(object sender, EventArgs e)
        {
            openGlHostPanel1.LoadMesh(meshFilePath);
            LoadMeshData();
            openGlHostPanel1.SetPanel(this.colorModePanel1);
            this.Text = $@"Controller - {fileDialog.SafeFileName}";
            this.Refresh();
            timer1.Enabled = checkBox1.Checked;
        }

        private void LoadMeshData()
        {
            foreach (string meshData in openGlHostPanel1.MeshData.Keys)
            {
                meshDataListBox.Items.Add(meshData);
            }
        }

        private void HandleMeshDataSelected(object sender, EventArgs e)
        {
            openGlHostPanel1.ActivateDataIndex(meshDataListBox.SelectedIndex);
        }
        private void Controller_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            openGlHostPanel1.TranslationFactor = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            openGlHostPanel1.ScaleFactor = (int) numericUpDown2.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            openGlHostPanel1.SetRotationAxis((Axis)rotationAxisComboBox.SelectedIndex);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            openGlHostPanel1.Rotate(Point3.One);
            openGlHostPanel1.Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox1.Checked;
        }

        private void resetTransformationsBtn_Click(object sender, EventArgs e)
        {
            openGlHostPanel1.ResetTransform();
            openGlHostPanel1.Refresh();
        }

        private void renderModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderMode renderMode = (RenderMode) renderModeComboBox.SelectedIndex;
            openGlHostPanel1.SetRenderMode(renderMode);
        }

        private void colorModePanel1_OnColorFunctionChanged(ColouringFunction colouringFunction)
        {
            openGlHostPanel1.SetColouringFunction(colouringFunction);
        }
    }
    
}
