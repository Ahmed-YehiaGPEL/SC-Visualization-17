using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace ColorUtilityPackage
{
    public static class ColorUtility
    {
        public static List<Color> ColourSet => ColorSet;
        public static ColouringFunction ColouringFunction => colouringFunction;

        private static readonly Color DefaultColor = Color.White;
        
        private static readonly List<Color> ColorSet = new List<Color>
        {
            Color.Blue,
            Color.Cyan,
            Color.FromArgb(0,255,0),
            Color.Yellow,
            Color.Orange,
            Color.Red
        };

        private static readonly int ColorsCount;
        private static ColouringFunction colouringFunction;

        static ColorUtility()
        {
            ColorsCount = ColorSet.Count;
            colouringFunction = ColouringFunction.None;
        }

        public static void SetColouringFunction(ColouringFunction function) => colouringFunction = function;

        public static Color CalculateColor(double value, double min, double max)
        {
            Color finalResult;
            switch (colouringFunction)
            {
                case ColouringFunction.Continous:
                    finalResult = CalculateColorContinous(value, min, max);
                    break;
                case ColouringFunction.Discrete:
                    finalResult = CalculateColorDiscrete(value, min, max); 
                    break;
                case ColouringFunction.None:
                    finalResult = DefaultColor;
                    Debug.WriteLine("Default Color");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return finalResult;
        }

        private static double CalculateDelta(double min, double max)
        {
            return colouringFunction == ColouringFunction.Discrete
                ? ((max - min) / ColorsCount)
                : ((max - min) / (ColorsCount - 1));
        }

        private static Color CalculateColorDiscrete(double value, double min, double max)
        {
            if (max < min)
            {
                return DefaultColor;
            }
            double delta = CalculateDelta(min, max);

            double alpha = (value - min) / delta;

            int index = Clamp((int)Math.Floor(alpha), 0, ColorSet.Count - 1);
            return ColorSet[index];
        }

        private static Color CalculateColorContinous(double value, double min, double max)
        {
            Color finalResult = DefaultColor;
            if (max <= min)
            {
                return finalResult;
            }
            double delta = CalculateDelta(min, max);

            int index = (int)((value - min) / delta);
            int secondIndex = Clamp(index + 1 , index, ColorSet.Count - 1);

            double s1 = (index * delta) + min;
            double s2 = ((index + 1) * delta) + min;

            double colorRatio = (value - s1) / (s2 - s1);

            Color firstCandidate = ColorSet[index];
            Color secondCandidate = ColorSet[secondIndex];

            finalResult = Lerp(firstCandidate, secondCandidate, colorRatio);

            return finalResult;
        }

        private static int Clamp(int value, int min, int max) => value < min ? min : (value > max ? max : value);

        private static Color Lerp(Color first, Color second, double ratio)
        {
            int r;
            int g;
            int b;

            if (first.R > second.R)
            {
                r = ((int)(Math.Floor((first.R - second.R) * (1 - ratio) + second.R)));
            }
            else if (first.R < second.R)
            {
                r = ((int)(Math.Floor((second.R - first.R) * ratio + first.R)));
            }
            else
            {
                r = ((int)(Math.Floor((double)first.R)));
            }

            if (first.G > second.G)
            {
                g = ((int)(Math.Floor((first.G - second.G) * (1 - ratio) + second.G)));
            }
            else if (first.G < second.G)
            {
                g = ((int)(Math.Floor((second.G - first.G) * ratio + first.G)));
            }
            else
            {
                g = ((int)(Math.Floor((double)first.G)));
            }

            if (first.B > second.B)
            {
                b = ((int)(Math.Floor((first.B - second.B) * (1 - ratio) + second.B)));
            }
            else if (first.B < second.B)
            {
                b = ((int)(Math.Floor((second.B - first.B) * ratio + first.B)));
            }
            else
            {
                b = ((int)(Math.Floor((double)first.B)));
            }

            Color finalResult = Color.FromArgb(r, g, b);

            return finalResult;
        }

    }
}
