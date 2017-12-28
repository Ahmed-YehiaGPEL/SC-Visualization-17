using System;
using System.Windows.Forms;
using OpenGlHostControl;
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
        }

        private void InitializeDefaults()
        {
            rotationAxisComboBox.SelectedIndex = 0;
            renderModeComboBox.SelectedIndex = 0;
            contourStyleComboBox.SelectedIndex = 0;

            glHostPanel.SetPanel(colorModePanel1);        
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

        private void FileLoadBtnClick(object sender, EventArgs e)
        {
            glHostPanel.LoadMesh(meshFilePath);
            LoadMeshData();
            toggleModelBodyRenderCheckbox.Checked = true;
            meshInfoTextBox.Text = $"\nVertices: {glHostPanel.LoadedMesh.VerticesCount}";
            this.Text = $@"Controller - {fileDialog.SafeFileName}";
            this.Refresh();
            animationTimer.Enabled = checkBox1.Checked;
        }

        private void LoadMeshData()
        {
            meshDataListBox.Items.Clear();
            foreach (string meshData in glHostPanel.MeshData.Keys)
            {
                meshDataListBox.Items.Add(meshData);
            }
            meshDataListBox.SelectedIndex = 0;
        }

        private void HandleMeshDataSelected(object sender, EventArgs e)
        {
            glHostPanel.ActivateDataIndex(meshDataListBox.SelectedItem.ToString());
        }

        private void Controller_Load(object sender, EventArgs e)
        {

        }

        private void TranslationFactorNumericValueChanged(object sender, EventArgs e)
        {
            glHostPanel.TranslationFactor = (int)numericUpDown1.Value;
        }

        private void ScaleFactorNumbericValueChanged(object sender, EventArgs e)
        {
            glHostPanel.ScaleFactor = (int) numericUpDown2.Value;
        }

        private void RotationAxisComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            glHostPanel.SetRotationAxis((Axis)rotationAxisComboBox.SelectedIndex);
        }

        private void AnimationTimerTick(object sender, EventArgs e)
        {
            glHostPanel.Rotate(Point3.One);
            glHostPanel.Refresh();
        }

        private void ToggleAnimationCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            animationTimer.Enabled = checkBox1.Checked;
        }

        private void ResetTransformationsBtnClick(object sender, EventArgs e)
        {
            glHostPanel.ResetTransform();
            glHostPanel.Refresh();
        }

        private void RenderModeComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            RenderMode renderMode = (RenderMode) renderModeComboBox.SelectedIndex;
            glHostPanel.SetRenderMode(renderMode);
        }

        private void ColorModePanel1_OnColorFunctionChanged(ColouringFunction colouringFunction)
        {
            glHostPanel.SetColouringFunction(colouringFunction);
        }

        private void CalculateIsoSurfacesButtonClick(object sender, EventArgs e)
        {
            int isoSurfacesCount = (int)isoSurfacesCountNumbericUpDown.Value;
            glHostPanel.RenderMeshIsoSurfaces(isoSurfacesCount);
            toggleIsoSurfacesRenderCheckbox.Checked = true;
        }

        private void ToggleIsoSurfacesRenderCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            glHostPanel.RenderIsoSurfaces = toggleIsoSurfacesRenderCheckbox.Checked;
        }

        private void CalculateLineContoursButton_Click(object sender, EventArgs e)
        {
            int  lineContoursCount = (int)lineContoursCountNumberic.Value;
            glHostPanel.RenderMeshLineContours(lineContoursCount);
            toggleLineContoursCheckBox.Checked = true;
        }

        private void ToggleModelBodyRenderCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            glHostPanel.LoadedMesh.Hidden = !toggleModelBodyRenderCheckbox.Checked;
            glHostPanel.Refresh();
        }

        private void glHostPanel_OnSelectedDataChanged()
        {
            if (toggleIsoSurfacesRenderCheckbox.Checked)
            {
                int isoSurfacesCount = (int)isoSurfacesCountNumbericUpDown.Value;
                glHostPanel.RenderMeshIsoSurfaces(isoSurfacesCount);
            }
            if (toggleLineContoursCheckBox.Checked)
            {
                int lineContoursCount = (int)lineContoursCountNumberic.Value;
                glHostPanel.RenderMeshLineContours(lineContoursCount);
            }
        }
    }
    
}
