using System.Drawing;
using Visualization.MathUtil;

namespace MeshLoader.Geometry
{
    public class IsoTriangle
    {
        public Point3 FirstVertex;
        public Point3 SecondVertex;
        public Point3 ThirdVertex;

        public Color Color;

        public IsoTriangle(Point3 firstVertex, Point3 secondVertex, Point3 thirdVertex)
        {
            FirstVertex = firstVertex;
            SecondVertex = secondVertex;
            ThirdVertex = thirdVertex;
        }

        public void SetColor(Color color)
        {
            this.Color = color;
        }
    }
}