using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ColorUtilityPackage;
using Tao.OpenGl;

namespace Visualization
{
    public class Face
    {
        //Data Members
        public uint[] Edges;
        public uint[] Vertices;

        private readonly Dictionary<ColouringFunction, Dictionary<int, Color>> colors =
            new Dictionary<ColouringFunction, Dictionary<int, Color>>();
        public Face(ElementType elementType)
        {
            switch (elementType)
            {
                case ElementType.FEQuad:
                case ElementType.IJKQuad:
                case ElementType.FEBrick:
                case ElementType.IJKBrick:
                    Edges = new uint[4];
                    Vertices = new uint[4];
                    break;
                case ElementType.Triangle:
                case ElementType.Tetrahedron:
                    Edges = new uint[3];
                    Vertices = new uint[3];
                    break;
                case ElementType.Line:
                    throw new Exception("Logical Error");
            }
        }

        public Face(uint e1, uint e2, uint e3)
        {
            Edges = new uint[3];
            Edges[0] = e1;
            Edges[1] = e2;
            Edges[2] = e3;
            Vertices = new uint[3];
        }

        public Face(uint e1, uint e2, uint e3, uint e4)
        {
            Edges = new uint[4];
            Edges[0] = e1;
            Edges[1] = e2;
            Edges[2] = e3;
            Edges[3] = e4;
            Vertices = new uint[4];
        }

        public void SetQuad(uint e1, uint e2, uint e3, uint e4)
        {
            Edges[0] = e1;
            Edges[1] = e2;
            Edges[2] = e3;
            Edges[3] = e4;
        }

        public void SetTriangle(uint e1, uint e2, uint e3)
        {
            Edges[0] = e1;
            Edges[1] = e2;
            Edges[2] = e3;
        }

        public void SetQuadVertices(uint p1, uint p2, uint p3, uint p4)
        {
            Vertices[0] = p1;
            Vertices[1] = p2;
            Vertices[2] = p3;
            Vertices[3] = p4;
        }

        public void SetTriangleVertices(uint p1, uint p2, uint p3)
        {
            Vertices[0] = p1;
            Vertices[1] = p2;
            Vertices[2] = p3;
        }

        public void Render(Zone owner, double min, double max, int index)
        {
            Gl.glBegin(Gl.GL_LINES);
            foreach (uint edge in Edges)
            {
                double value = new[]
                {
                    owner.Vertices[owner.Edges[edge].Start].Data[index],
                    owner.Vertices[owner.Edges[edge].End].Data[index]
                }.Average();

                Color color = owner.Edges[edge].GetColor(value, min, max,index);

                Gl.glColor3d(color.R / 255.0, color.G / 255.0, color.B / 255.0);

                owner.RenderEdge(edge);
            }
            Gl.glEnd();
        }

        public Color GetColor(double averageValue, double minData, double maxData,int dataIndex)
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