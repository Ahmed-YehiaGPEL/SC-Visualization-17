using System.Collections.Generic;
using System.Drawing;
using MeshLoader.Geometry;
using Tao.OpenGl;
using Visualization.MathUtil;

namespace Visualization.Utilities.LineContours
{
    public class LineContour
    {
        public List<Point3> Points;
        public Color Color;
        public LineContour()
        {
            Points = new List<Point3>();
            Color = Color.Blue;
        }
        public void AddPoint(Point3 point)
        {
            this.Points.Add(point);
        }

        public void Render()
        {
            Gl.glBegin(Gl.GL_LINES);
            foreach (Point3 linePoint in Points)
            {
                Gl.glColor3d(Color.R / 255.0, Color.G / 255.0, Color.B / 255.0);
                linePoint.glTell();
            }
            Gl.glEnd();
        }
    }
}