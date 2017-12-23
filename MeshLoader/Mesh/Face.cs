using System;
using System.Drawing;
using ColorUtilityPackage;
using Tao.OpenGl;

namespace Visualization
{
    public class Face
    {
        //Data Members
        public uint[] Edges;
        public uint[] Vertices;
        //Constructors
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
        //Methods
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

        public void glTell(Zone owner, double min, double max, int index)
        {
            Gl.glBegin(Gl.GL_LINES);
            foreach (uint edge in Edges)
            {
                double value = Average(owner.Vertices[owner.Edges[edge].Start].Data[index],
                    owner.Vertices[owner.Edges[edge].End].Data[index]);

                Color color = ColorUtility.CalculateColor(value, min, max);

                Gl.glColor3d(color.R / 255.0, color.G / 255.0, color.B / 255.0);

                owner.glTellEdge(edge);
            }
            Gl.glEnd();
        }

        private double Average(params double[] par)
        {
            double sum = 0;
            for (int index = 0; index < par.Length; index++)
            {
                sum += par[index];
            }
            sum /= par.Length;
            return sum;
        }

    }
}