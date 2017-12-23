using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;
using Visualization;

namespace Visualisation_2017
{
    static class Utils
    {
        public static void MeshDraw(this Mesh mesh)
        {
            Gl.glClearColor(1, 1, 1, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            //Gl.glMatrixMode(Gl.GL_MODELVIEW);
            foreach (Zone meshZone in mesh.Zones)
            {
                foreach (Face meshZoneFace in meshZone.Faces)
                {
                    Gl.glBegin(Gl.GL_LINES);
                    foreach (uint edgeUint in meshZoneFace.Edges)
                    {
                        Edge edge = meshZone.Edges[edgeUint];
                        Gl.glColor3d(0,0,0);
                        meshZone.Vertices[edge.Start].Position.glTell();
                        meshZone.Vertices[edge.End].Position.glTell();
                    }
                    Gl.glEnd();
                    Gl.glFlush();
                }
            }
            mesh.RenderWireFrame();
        }
    }
}
