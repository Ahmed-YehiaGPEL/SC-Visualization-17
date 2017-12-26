using System;
using System.Windows.Forms;
using ColorModePanelControl;
using OpenGlHostControl;
using Visualization;
using ColorUtilityPackage;
using Visualization.MathUtil;

namespace Visualisation_2017
{
    
    public partial class Controller : Form
    {
        private string meshFilePath;

        public Controller()
        {
            InitializeComponent();
            InitializeDefaults();
            openGlHostPanel1.SetPanel(colorModePanel1);        
        }

        private void InitializeDefaults()
        {
            rotationAxisComboBox.SelectedIndex = 0;
            renderModeComboBox.SelectedIndex = 0;
            contourStyleComboBox.SelectedIndex = 0;
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
            toggleModelBodyRenderCheckbox.Checked = true;
            meshInfoTextBox.Text = $"\nVertices: {openGlHostPanel1.LoadedMesh.VerticesCount}";
            this.Text = $@"Controller - {fileDialog.SafeFileName}";
            this.Refresh();
            timer1.Enabled = checkBox1.Checked;
        }

        private void LoadMeshData()
        {
            meshDataListBox.Items.Clear();
            foreach (string meshData in openGlHostPanel1.MeshData.Keys)
            {
                meshDataListBox.Items.Add(meshData);
            }
            meshDataListBox.SelectedIndex = 0;
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

        private void CalculateIsoSurfacesButtonClick(object sender, EventArgs e)
        {
            int isoSurfacesCount = (int)isoSurfacesCountNumbericUpDown.Value;
            openGlHostPanel1.RenderMeshIsoSurfaces(isoSurfacesCount);
            toggleIsoSurfacesRenderCheckbox.Checked = true;
        }

        private void toggleIsoSurfacesRenderCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            openGlHostPanel1.RenderIsoSurfaces = toggleIsoSurfacesRenderCheckbox.Checked;
        }

        private void calculateLineContoursButton_Click(object sender, EventArgs e)
        {
            int  lineContoursCount = (int)lineContoursCountNumberic.Value;
            openGlHostPanel1.RenderMeshLineContours(lineContoursCount);
            toggleLineContoursCheckBox.Checked = true;
        }

        private void toggleModelBodyRenderCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            openGlHostPanel1.LoadedMesh.Hidden = !toggleModelBodyRenderCheckbox.Checked;
            openGlHostPanel1.Refresh();
        }
    }
    
}
