using System.Collections.Generic;
using Tao.OpenGl;

namespace MeshLoader.Geometry
{
    public class IsoSurface
    {
        public List<IsoTriangle> SurfaceTriangles;

        public IsoSurface()
        {
            SurfaceTriangles = new List<IsoTriangle>();
        }

        public void AddTriangle(IsoTriangle triangle)
        {
            this.SurfaceTriangles.Add(triangle);
        }

        public void Render()
        {
            Gl.glBegin(Gl.GL_TRIANGLES);
            foreach (IsoTriangle surfaceTriangle in SurfaceTriangles)
            {
                Gl.glColor3d(surfaceTriangle.Color.R / 255.0, surfaceTriangle.Color.G / 255.0, surfaceTriangle.Color.B / 255.0);
                surfaceTriangle.FirstVertex.glTell();
                surfaceTriangle.SecondVertex.glTell();
                surfaceTriangle.ThirdVertex.glTell();
            }
            Gl.glEnd();
        }
    }
}
