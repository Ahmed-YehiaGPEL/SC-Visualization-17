using System.Collections.Generic;
using System.Drawing;
using ColorUtilityPackage;

namespace Visualization
{
    public class Edge
    {
        public uint Start;
        public uint End;
        private readonly Dictionary<ColouringFunction, Dictionary<int, Color>> colors =
             new Dictionary<ColouringFunction, Dictionary<int, Color>>();

        public Edge() : this(0, 0)
        {
        }

        public Edge(uint st, uint end)
        {
            Start = st;
            End = end;
        }

        public void Set(uint st, uint end)
        {
            Start = st;
            End = end;
        }

        public Color GetColor(double averageValue, double minData, double maxData, int dataIndex)
        {

            Dictionary<int, Color> colorDictionary;
            colors.TryGetValue(ColorUtility.ColouringFunction, out colorDictionary);
            if (colorDictionary == null)
            {
                colorDictionary = new Dictionary<int, Color>();
                //Calculate Color
                Color value = ColorUtility.CalculateColor(averageValue, minData, maxData);
                colorDictionary.Add(dataIndex, value);
                colors.Add(ColorUtility.ColouringFunction, colorDictionary);
                return value;
            }
            else
            {
                if (colorDictionary.ContainsKey(dataIndex))
                    return colors[ColorUtility.ColouringFunction][dataIndex];

                Color value = ColorUtility.CalculateColor(averageValue, minData, maxData);
                colorDictionary.Add(dataIndex, value);
                colors[ColorUtility.ColouringFunction] = colorDictionary;
                return value;
            }
        }
    }
}