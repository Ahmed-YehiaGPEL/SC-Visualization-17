using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ColorModePanelControl
{
    public static class DialogExtension
    {
        public static Color ShowAndGetResult(this ColorDialog dialog)
        {
            return dialog.ShowDialog() == DialogResult.OK ? dialog.Color : Color.Black;
        }
    }
}
