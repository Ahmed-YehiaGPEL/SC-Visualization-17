using System.Drawing;
using ColorUtilityPackage;
using Visualization.MathUtil;
using Visualization.Utilities.LineContours;

namespace Visualization.Utilities.IsoSurfaceCalculations
{
    public static class EdgeUtilities
    {
        public static Point3 GetIsoValuePoint(this Edge self, Zone zone, Element element, double isoValue, int dataIndex)
        {
            Vertex firstEdgeStartVertex = zone.Vertices[element.VertInOrder[self.Start]];
            Vertex firstEdgeEndVertex = zone.Vertices[element.VertInOrder[self.End]];

            double startData = firstEdgeStartVertex.Data[dataIndex];
            double endData = firstEdgeEndVertex.Data[dataIndex];

            double alpha = Mathf.Lerp(isoValue, startData, endData);

            Point3 finalPoint = Mathf.Lerp(alpha,
                firstEdgeStartVertex.Position, firstEdgeEndVertex.Position);

            return finalPoint;
        }

        public static void CalculateContour(this Edge self, Zone zone, double contourValue, int dataIndex,double globalMin, double globalMax, ref LineContour lineContour)
        {
            Vertex startVertex = zone.Vertices[self.Start];
            Vertex endVertex = zone.Vertices[self.End];

            double startData = startVertex.Data[dataIndex];
            double endData = endVertex.Data[dataIndex];

            if (Mathf.Ranges(contourValue, startData, endData))
            {
                double alpha = Mathf.Lerp(contourValue, startData, endData);
                Point3 finalPoint = Mathf.Lerp(alpha, startVertex.Position, endVertex.Position);

                Color contourColor = ColorUtility.CalculateColor(contourValue,globalMin, globalMax);

                lineContour.AddPoint(finalPoint);
                lineContour.Color = contourColor;
            }
         
        }
    }
}
