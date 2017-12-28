using System;

namespace Visualization.MathUtil
{
    public static class Mathf
    {
        public static double ToRadians(double degrees)
        {
            return (double)(System.Math.PI / 180 * degrees);
        }

        public static double ToDegrees(double radians)
        {
            return (double)(180 / System.Math.PI * radians);
        }

        public static bool Ranges(double value, double left, double right)
        {
            if (left > right)
            {
                double temp = left;
                left = right;
                right = temp;
            }
            return value >= left && value <= right;
        }

        public static bool NearlyEqual(ref double val1, ref double val2, ref double tolerance)
        {
            if (val1 != 0)
            {
                double diff = System.Math.Abs((val1 - val2) / val1);
                return diff <= tolerance;
            }
            else
            {
                return System.Math.Abs(val2) <= tolerance;
            }
        }

        public static bool NearlyEqual(double val1, double val2, double tolerance)
        {
            val1 = System.Math.Abs((val1 - val2) / val1);
            return val1 <= tolerance;
        }

        public static bool NearlyEqual2(double val1, double val2, double tolerance)
        {
            val1 = System.Math.Abs((val1 - val2));
            return val1 <= tolerance;
        }

        public static double angle(Point3 p1, Point3 p2)
        {
            return System.Math.Atan2(p2.y - p1.y, p2.x - p1.x);
        }

        private static double signed_traingle_area(Point3 p1, Point3 p2, Point3 p3)
        {
            return ((p1.x * p2.y - p1.y * p2.x + p1.y * p3.x - p1.x * p3.y + p2.x * p3.y - p3.x * p2.y) / 2.0);

        }

        public static bool ccw(Point3 p1, Point3 p2, Point3 p3)
        {
            return (signed_traingle_area(p1, p2, p3) < 0.000001);
        }

        public static bool colinear(Point3 p1, Point3 p2, Point3 p3)
        {

            return (System.Math.Abs(signed_traingle_area(p1, p2, p3)) <= 0.000001);
        }

        public static double GelLengthBetween2Points(Point3 p1, Point3 p2)
        {
            return System.Math.Sqrt(System.Math.Pow((p2.y - p1.y), 2) + System.Math.Pow((p2.x - p1.x), 2));
        }

        public static Point3 Lerp(double t, Point3 a, Point3 b)
        {
            return a + t * (b - a);
        }

        public static double Lerp(double value, double start, double end)
        {
            double alpha = (value - start) / (end - start);
            return alpha;
        }

        public static double SliceInterval(double count, double min, double max)
        {
            double interval = (max - min) / (count);
            return interval;
        }
    }
}
