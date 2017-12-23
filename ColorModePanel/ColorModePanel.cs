using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ColorUtilityPackage;

namespace ColorModePanelControl
{
    public partial class ColorModePanel : UserControl
    {
        #region Events

        public delegate void OnColorFunctionChangedDelegate(ColouringFunction function);
        public delegate void OnColorSetChangedDelegate();

        public event OnColorSetChangedDelegate OnColorSetChanged;
        public event OnColorFunctionChangedDelegate OnColorFunctionChanged;
        #endregion

        public ColouringFunction ColouringFunction
        {
            get { return ColorUtility.ColouringFunction; }
            set
            {
                ColorUtility.SetColouringFunction(value);
            }
        }

        private readonly List<Color> colorSet = ColorUtility.ColourSet;

        public ColorModePanel()
        {
            InitializeComponent();
            DrawSetColors();
        }
    
        private void SetColouringFunction(ColouringFunction function)
        {
            ColorUtility.SetColouringFunction(function);
            ColouringFunction = function;
            OnColorFunctionChanged?.Invoke(function);
        }

        private void colorSetChangeBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < colorSet.Count; i++)
            {
                DialogResult result = colorSetDialog.ShowDialog(this.Parent);
                if (result == DialogResult.OK)
                {
                    colorSet[i] = colorSetDialog.Color;
                }
            }

            DrawSetColors();
        }

        private void DrawSetColors()
        {
            setColor1.BackColor = colorSet[0];
            setColor2.BackColor = colorSet[1];
            setColor3.BackColor = colorSet[2];
            setColor4.BackColor = colorSet[3];
            setColor5.BackColor = colorSet[4];
            setColor6.BackColor = colorSet[5];
        }

        private void ChangeSetColor(object sender, EventArgs e)
        {
            Color chosenColor = colorSetDialog.ShowAndGetResult();
            Control panel = sender as Control;
            switch ((int.Parse(panel.Tag as string)))
            {
                case 1:
                    colorSet[0] = chosenColor;
                    setColor1.BackColor = chosenColor;
                    break;
                case 2:
                    colorSet[1] = chosenColor;
                    setColor2.BackColor = chosenColor;
                    break;
                case 3:
                    colorSet[2] = chosenColor;
                    setColor3.BackColor = chosenColor;
                    break;
                case 4:
                    colorSet[3] = chosenColor;
                    setColor4.BackColor = chosenColor;
                    break;
                case 5:
                    colorSet[4] = chosenColor;
                    setColor5.BackColor = chosenColor;
                    break;
                case 6:
                    colorSet[5] = chosenColor;
                    setColor6.BackColor = chosenColor;
                    break;
            }
            OnColorSetChanged?.Invoke();
        }

        private void SelectColorFunction(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            ColouringFunction function = (ColouringFunction)(int.Parse(radioButton.Tag.ToString()));
            SetColouringFunction(function);           
        }
    }
}
