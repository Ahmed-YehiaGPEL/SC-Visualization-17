using System.Drawing;
using ColorUtilityPackage;
using Tao.OpenGl;

namespace Visualization
{
    public class Zone
    {
        //There should be a field for T
        //public string Title;
        public uint VertexCount;
        public uint ElementCount;
        public uint FaceCount;
        public uint EdgeCount; //Redundant
        public uint DataCount; //Number of data items per node.
        public Vertex[] Vertices;
        public Edge[] Edges;
        public Face[] Faces;
        public Element[] Elements;
        public ElementType ElementType;
        //		public int FaceType;//GL_LINE_STRIP or GL_TRIANGLES or GL_QUADS
        public Zone(
            ElementType elementType,
            uint vertexCount,
            uint elementCount,
            uint faceCount,
            uint edgeCount,
            uint dataCount)
        {
            ElementType = elementType;
            VertexCount = vertexCount;
            ElementCount = elementCount;
            FaceCount = faceCount;
            EdgeCount = edgeCount;
            DataCount = dataCount;
            if (vertexCount == 0)
            {
                Vertices = null;
                Faces = null;
                Edges = null;
                Elements = null;
                return;
            }
            Vertices = new Vertex[VertexCount];
            for (uint i = 0; i < VertexCount; i++)
            {
                Vertices[i] = new Vertex();
                Vertices[i].Data = new double[DataCount];
            }
            if (ElementType == ElementType.Line)
            {
                Faces = null;
                Edges = new Edge[EdgeCount];
                Elements = null;
                for (uint i = 0; i < EdgeCount; i++)
                    Edges[i] = new Edge();
            }
            else
            {
                Elements = new Element[ElementCount];
                for (uint i = 0; i < ElementCount; i++)
                    Elements[i] = new Element(ElementType);
                Faces = new Face[FaceCount];
                for (uint i = 0; i < FaceCount; i++)
                    Faces[i] = new Face(ElementType);
                Edges = new Edge[EdgeCount];
                for (uint i = 0; i < EdgeCount; i++)
                    Edges[i] = new Edge();
            }
        }

        public Zone()
        {
        }
        /// <summary>
        /// Finds the minimum and maximum value for each of the xyz coordinates,
        /// and assigns them to min and max.
        /// </summary>
        /// <param name="min">
        /// A point whose xyz coordinates are the smallest among all the vertices
        /// of the zone. It might not be a vertex in the zone.
        /// </param>
        /// <param name="max">
        /// A point whose xyz coordinates are the greatest among all the vertices
        /// of the zone. It might not be a vertex in the zone.
        /// </param>
        public void GetMinMaxVertices(Point3 min, Point3 max)
        {
            min.z = min.y = min.x = double.PositiveInfinity;
            max.z = max.y = max.x = double.NegativeInfinity;
            Point3 p;
            foreach (Vertex v in Vertices)
            {
                p = v.Position;
                if (p.x < min.x) min.x = p.x;
                if (p.y < min.y) min.y = p.y;
                if (p.z < min.z) min.z = p.z;
                if (p.x > max.x) max.x = p.x;
                if (p.y > max.y) max.y = p.y;
                if (p.z > max.z) max.z = p.z;
            }
        }

        public void glDraw(Mesh owner)
        {
            for (uint i = 0; i < ElementCount; i++)
                Elements[i].glTell(this, owner.GetMinimumBounds(owner.DataIndex),owner.GetMaximumBounds(owner.DataIndex),owner.DataIndex);
        }

        public void glDrawFilled(Mesh owner)
        {
            int index = owner.DataIndex;
            double minData = owner.GetMinimumBounds(index);
            double maxData = owner.GetMaximumBounds(index);
            switch (ElementType)
            {
                case ElementType.Tetrahedron:
                case ElementType.Triangle:
                    Gl.glBegin(Gl.GL_TRIANGLES);
                    foreach (Face f in Faces)
                    {
                        double averageValue = Average(Vertices[f.Vertices[0]].Data[index],
                            Vertices[f.Vertices[1]].Data[index],
                            Vertices[f.Vertices[2]].Data[index]);

                        Color faceColor = ColorUtility.CalculateColor(averageValue, minData, maxData);

                        Gl.glColor3d(faceColor.R / 255.0, faceColor.G / 255.0, faceColor.B / 255.0);

                        Vertices[f.Vertices[0]].Position.glTell();
                        Vertices[f.Vertices[1]].Position.glTell();
                        Vertices[f.Vertices[2]].Position.glTell();
                    }
                    Gl.glEnd();
                    break;
                case ElementType.IJKBrick:
                case ElementType.IJKQuad:
                case ElementType.FEBrick:
                case ElementType.FEQuad:
                    Gl.glBegin(Gl.GL_QUADS);
                    foreach (Face f in Faces)
                    {

                        double averageValue = Average(Vertices[f.Vertices[0]].Data[index],
                            Vertices[f.Vertices[1]].Data[index],
                            Vertices[f.Vertices[2]].Data[index],
                            Vertices[f.Vertices[3]].Data[index]);

                        Color faceColor = ColorUtility.CalculateColor(averageValue, minData, maxData);

                        Gl.glColor3d(faceColor.R / 255.0, faceColor.G / 255.0, faceColor.B / 255.0);

                        Vertices[f.Vertices[0]].Position.glTell();
                        Vertices[f.Vertices[1]].Position.glTell();
                        Vertices[f.Vertices[2]].Position.glTell();
                        Vertices[f.Vertices[3]].Position.glTell();
                    }
                    Gl.glEnd();
                    break;
            }
        }

        public void glTellEdge(uint index)
        {
            Vertices[Edges[index].Start].Position.glTell();
            Vertices[Edges[index].End].Position.glTell();
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