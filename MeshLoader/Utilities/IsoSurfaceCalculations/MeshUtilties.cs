using System;
using System.Collections.Generic;
using System.Linq;
using ColorUtilityPackage;
using MeshLoader.Geometry;
using Visualization.Gemoetry;
using Visualization.MathUtil;
using Visualization.Utilities.IsoSurfaceCalculations;
using Visualization.Utilities.LineContours;

namespace Visualization.Utilities.Contouring
{
    public static class MeshUtilties
    {
        public static List<IsoSurface> CalculateIsoSurface(this Mesh self, double numberOfSurfaces, int dataIndex)
        {
            double minOfData = self.GetMinimumBounds(dataIndex);
            double maxOfData = self.GetMaximumBounds(dataIndex);

            double interval = Mathf.SliceInterval(numberOfSurfaces, minOfData, maxOfData);

            List<IsoSurface> meshSurface = new List<IsoSurface>();

            for (double isoValue = minOfData; isoValue <= numberOfSurfaces; isoValue += interval)
            {
                IsoSurface finalSurface = new IsoSurface();
                foreach (Zone zone in self.Zones)
                {
                    foreach (Element element in zone.Elements)
                    {
                        double[] dataArray = new double[8];

                        for (int index = 0; index < element.VertInOrder.Length; index++)
                        {
                            uint vertex = element.VertInOrder[index];

                            dataArray[index] = (zone.Vertices[vertex].Data[dataIndex]);
                        }
                        byte caseNumber = ISOSurface.GetElementCase(dataArray, isoValue);

                        int[] caseEdges = ISOSurface.GetCaseEdges(caseNumber);
                        for (int i = 0; i < caseEdges.Length - 1; i += 3)
                        {
                            if (caseEdges[i] != -1 && caseEdges[i + 1] != -1 && caseEdges[i + 2] != -1)
                            {
                                Edge firstEdge = ISOSurface.GetEdgePoints(caseEdges[i]);
                                Point3 firstEdgeFinalPoint = firstEdge.GetIsoValuePoint(zone, element, isoValue,
                                    dataIndex);

                                Edge secondEdge = ISOSurface.GetEdgePoints(caseEdges[i + 1]);
                                Point3 secondEdgeFinalPoint = secondEdge.GetIsoValuePoint(zone, element, isoValue,
                                    dataIndex);

                                Edge thirdEdge = ISOSurface.GetEdgePoints(caseEdges[i + 2]);
                                Point3 thirdEdgeFinalPoint = thirdEdge.GetIsoValuePoint(zone, element, isoValue,
                                    dataIndex);

                                IsoTriangle resultTriangle = new IsoTriangle(firstEdgeFinalPoint, secondEdgeFinalPoint,
                                                                             thirdEdgeFinalPoint)
                                {
                                    Color = ColorUtility.CalculateColor(isoValue, minOfData, maxOfData)
                                };

                                finalSurface.AddTriangle(resultTriangle);
                            }
                        }
                    }
                }
                meshSurface.Add(finalSurface);
            }
            return meshSurface;
        }

        public static List<LineContour> CalculateLineContours(this Mesh self, double numberofLines, int dataIndex)
        {
            double minOfData = self.GetMinimumBounds(dataIndex);
            double maxOfData = self.GetMaximumBounds(dataIndex);

            double interval = Mathf.SliceInterval(numberofLines, minOfData, maxOfData);

            List<LineContour> finalContours = new List<LineContour>();

            for (double contourValue = minOfData+interval; contourValue <= numberofLines; contourValue+= interval)
            {
                LineContour lineContour = new LineContour();

                foreach (Zone zone in self.Zones)
                {
                    foreach (Element element in zone.Elements)
                    {
                        switch (zone.ElementType)
                        {
                            case ElementType.Tetrahedron:
                            case ElementType.Triangle:
                                foreach (Face zoneFace in zone.Faces)
                                {
                                    foreach (uint zoneFaceEdge in zoneFace.Edges)
                                    {
                                        Edge edge = zone.Edges[zoneFaceEdge];
                                        edge.CalculateContour(zone, contourValue, dataIndex, ref lineContour);
                                    }
                                }
                                break;
                            case ElementType.IJKBrick:
                            case ElementType.IJKQuad:
                            case ElementType.FEBrick:
                            case ElementType.FEQuad:
                                foreach (Face zoneFace in zone.Faces)
                                {
                                    string caseCode = GetCaseCode(dataIndex, contourValue, zone, zoneFace);

                                    if (caseCode == "0101")
                                    {
                                       
                                        Point3 firstPoint;
                                        Point3 secondPoint;
                                        Point3 finalPoint;
                                        double alpha = Mathf.Lerp(contourValue, minOfData, maxOfData);
                                        double average = new[]
                                        {
                                            zone.Vertices[zoneFace.Vertices[0]].Data[dataIndex],
                                            zone.Vertices[zoneFace.Vertices[1]].Data[dataIndex],
                                            zone.Vertices[zoneFace.Vertices[2]].Data[dataIndex],
                                            zone.Vertices[zoneFace.Vertices[3]].Data[dataIndex]
                                        }.Average();

                                        if (average > contourValue)
                                        {
                                            for (int i = 0; i < 3; i++)
                                            {
                                                firstPoint = zone.Vertices[i].Position;

                                                secondPoint = zone.Vertices[i + 1].Position;
                                                finalPoint = Mathf.Lerp(alpha, firstPoint, secondPoint);

                                                lineContour.AddPoint(finalPoint);
                                            }

                                            firstPoint = zone.Vertices[3].Position;
                                            secondPoint = zone.Vertices[0].Position;
                                            finalPoint = Mathf.Lerp(alpha, firstPoint, secondPoint);

                                            lineContour.AddPoint(finalPoint);
                                        }
                                        else
                                        {
                                            for (int i = 1; i < 3; i++)
                                            {
                                                firstPoint = zone.Vertices[i].Position;

                                                secondPoint = zone.Vertices[i + 1].Position;
                                                finalPoint = Mathf.Lerp(alpha, firstPoint, secondPoint);

                                                lineContour.AddPoint(finalPoint);
                                            }

                                            firstPoint = zone.Vertices[3].Position;
                                            secondPoint = zone.Vertices[0].Position;

                                            finalPoint = Mathf.Lerp(alpha, firstPoint, secondPoint);

                                            lineContour.AddPoint(finalPoint);

                                            firstPoint = zone.Vertices[0].Position;
                                            secondPoint = zone.Vertices[1].Position;
                                            finalPoint = Mathf.Lerp(alpha, firstPoint, secondPoint);

                                            lineContour.AddPoint(finalPoint);
                                        }

                                    }
                                    else if (caseCode == "1010")
                                    {
                                        Point3 firstPoint;
                                        Point3 secondPoint;
                                        Point3 finalPoint;
                                        double alpha = Mathf.Lerp(contourValue, minOfData, maxOfData);

                                        double average = new[]
                                        {
                                            zone.Vertices[zoneFace.Vertices[0]].Data[dataIndex],
                                            zone.Vertices[zoneFace.Vertices[1]].Data[dataIndex],
                                            zone.Vertices[zoneFace.Vertices[2]].Data[dataIndex],
                                            zone.Vertices[zoneFace.Vertices[3]].Data[dataIndex]
                                        }.Average();


                                        if (average < contourValue)
                                        {
                                            for (int i = 0; i < 3; i++)
                                            {
                                                firstPoint = zone.Vertices[i].Position;

                                                secondPoint = zone.Vertices[i + 1].Position;
                                                finalPoint = Mathf.Lerp(alpha, firstPoint, secondPoint);

                                                lineContour.AddPoint(finalPoint);
                                            }

                                            firstPoint = zone.Vertices[3].Position;
                                            secondPoint = zone.Vertices[0].Position;
                                            finalPoint = Mathf.Lerp(alpha, firstPoint, secondPoint);

                                            lineContour.AddPoint(finalPoint);
                                        }
                                        else
                                        {
                                            for (int i = 1; i < 3; i++)
                                            {
                                                firstPoint = zone.Vertices[i].Position;

                                                secondPoint = zone.Vertices[i + 1].Position;
                                                finalPoint = Mathf.Lerp(alpha, firstPoint, secondPoint);

                                                lineContour.AddPoint(finalPoint);
                                            }

                                            firstPoint = zone.Vertices[3].Position;
                                            secondPoint = zone.Vertices[0].Position;

                                            finalPoint = Mathf.Lerp(alpha, firstPoint, secondPoint);

                                            lineContour.AddPoint(finalPoint);

                                            firstPoint = zone.Vertices[0].Position;
                                            secondPoint = zone.Vertices[1].Position;
                                            finalPoint = Mathf.Lerp(alpha, firstPoint, secondPoint);

                                            lineContour.AddPoint(finalPoint);
                                        }

                                    }
                                    else
                                    {
                                        foreach (uint zoneFaceEdge in zoneFace.Edges)
                                        {
                                            Edge edge = zone.Edges[zoneFaceEdge];
                                            edge.CalculateContour(zone, contourValue, dataIndex, ref lineContour);
                                        }
                                    }

                                }
                                break;
                            case ElementType.Line:
                                continue;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }
                finalContours.Add(lineContour);
            }
            return finalContours;
        }

        private static string GetCaseCode(int dataIndex, double contourValue, Zone zone, Face zoneFace)
        {
            string caseNum = "";
            for (int i = 0; i < 4; i++)
            {
                if (zone.Vertices[zoneFace.Vertices[i]].Data[dataIndex] > contourValue)
                {
                    caseNum += "1";
                }
                else
                {
                    caseNum += "0";
                }
            }

            return caseNum;
        }
    }
}
