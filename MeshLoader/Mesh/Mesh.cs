using System;
using System.Collections;
using System.Collections.Generic;
using MeshLoader.Geometry;
using Tao.OpenGl;
using Visualization.DataStructures;
using Visualization.MathUtil;
using Visualization.Utilities.Contouring;
using Visualization.Utilities.LineContours;

namespace Visualization
{
    public class Mesh
    {
        private const int DefaultMeshSize = 120;

        public LinkedList Zones;
        /// <summary>
        /// Specifies the index of a given variable into the
        /// data list of each vertex. For example, 
        /// VarToIndex["Temperature"] is the index of the 
        /// variable "Temperature" in the Data array of each vertex.
        /// The first variable is given the index 0.
        /// </summary>
        public Hashtable VarToIndex;
        public Matrix Transformation = new Matrix();
        public bool Hidden = false;
        public bool HasTitle;
        public string Title;
        public int DataIndex => dataIndex;
        public long VerticesCount => verticesCount;

        private long verticesCount;
        private Matrix originalTransformation;
        private List<double> minimumBounds;
        private List<double> maximumBounds;

        private List<IsoSurface> isoSurfaces;
        private readonly Dictionary<int, List<IsoSurface>> isoSurfaceCach = new Dictionary<int, List<IsoSurface>>();

        private List<LineContour> lineContours;
        private readonly Dictionary<int,List<LineContour>> lineContoursCach = new Dictionary<int, List<LineContour>>();

        private int dataIndex;
        private bool renderIsoSurfaces;
        private bool renderLineContours;

        public Mesh(string fileName) : this(fileName, DefaultMeshSize) 
        {

        }

        private Mesh(string fileName, double size)
        {
            //Define data structures
            Zones = new LinkedList();
            VarToIndex = new Hashtable();

            //Load mesh
            Parser parser = new Parser();
            parser.LoadMesh(fileName, this);

            //Prepare transformations so that the mesh is centered and scaled
            SetupTransformation(size);
        }

        public void RenderWireFrame()
        {
            if (Hidden) return;
            Gl.glColor3f(.1f, 1, 0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glMultMatrixd(Transformation.Data);
            foreach (Zone z in Zones)
            {
                z.glDraw(this);
            }
            Gl.glPopMatrix();
        }

        public void RenderShape()
        {
            if (Hidden) return;
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glMultMatrixd(Transformation.Data);
            foreach (Zone z in Zones)
            {
                z.glDrawFilled(this);
            }
            Gl.glPopMatrix();
        }
        
        public void CalculateMinMaxBounds()
        {
            ResetBounds();
            minimumBounds = new List<double>();
            maximumBounds = new List<double>();
            double minVal;
            double maxVal;
            for (int i = 0; i < this.VarToIndex.Count; i++)
            {
                GetMinMaxValues((uint)i, out minVal, out maxVal);
                minimumBounds.Add(minVal);
                maximumBounds.Add(maxVal);
            }
        }

        public void CalculateAndRenderIsoSurfaces(int isoSurfacesCount, int indexOfData)
        {
            List<IsoSurface> surfaces;
            isoSurfaceCach.TryGetValue(indexOfData, out surfaces);
            if (surfaces == null)
            {
                surfaces = this.CalculateIsoSurface(isoSurfacesCount, indexOfData);
                isoSurfaceCach.Add(indexOfData, surfaces);
            }
            isoSurfaces = surfaces;

            renderIsoSurfaces = true;
            RenderIsoSurfaces();
        }

        public void CalculateAndRenderLineContours(int contoursCount, int indexOfData)
        {
            List<LineContour> contours;
            lineContoursCach.TryGetValue(indexOfData, out contours);
            if (contours == null)
            {
                contours = this.CalculateLineContours(contoursCount, indexOfData);
                lineContoursCach.Add(indexOfData, contours);
            }
            lineContours = contours;

            renderLineContours = true;
            RenderLineContours();
        }

        public void RenderIsoSurfaces()
        {
            if (renderIsoSurfaces == false) return;
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glMultMatrixd(Transformation.Data);
            foreach (IsoSurface surface in isoSurfaces)
            {
                surface.Render();
            }
            Gl.glPopMatrix();
        }

        public void RenderLineContours()
        {
            if (renderLineContours == false) return;

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();
            Gl.glMultMatrixd(Transformation.Data);
            foreach (LineContour lineContour in lineContours)
            {
                lineContour.Render();
            }
            Gl.glPopMatrix();
        }

        public void RestoreTransformation() => Transformation = originalTransformation.Clone();

        public double GetMinimumBounds(int index) => this.minimumBounds[index];

        public double GetMaximumBounds(int index) => this.maximumBounds[index];

        public void SetDataIndex(int dataIndex) => this.dataIndex = dataIndex;

        private void GetMinMaxValues(uint varIndex, out double min, out double max)
        {
            min = double.MaxValue;
            max = double.MinValue;
            foreach (Zone zone in Zones)
                foreach (Vertex v in zone.Vertices)
                {
                    if (v.Data[varIndex] < min)
                        min = v.Data[varIndex];
                    if (v.Data[varIndex] > max)
                        max = v.Data[varIndex];
                }
        }

        /// <summary>
        /// Sets up a transformation that places the center of the mesh at
        /// the origin, and uniformly scales it so that the longest dimension
        /// has a length value = size
        /// </summary>
        /// <param name="size">
        /// Specifies the desired length of the longest dimension of the mesh.
        /// The mesh is uniformly scaled so that the longest dimension has 
        /// this length value.
        /// </param>
        private void SetupTransformation(double size)
        {
            Point3 candidateMin = new Point3();
            Point3 candidateMax = new Point3();
            isoSurfaces = new List<IsoSurface>();
            lineContours = new List<LineContour>();
            Point3 min = new Point3(double.PositiveInfinity,
                double.PositiveInfinity,
                double.PositiveInfinity);

            Point3 max = new Point3(double.NegativeInfinity,
                double.NegativeInfinity,
                double.NegativeInfinity);

            foreach (Zone zone in Zones)
            {
                zone.GetMinMaxVertices(candidateMin, candidateMax);
                if (candidateMin.x < min.x) min.x = candidateMin.x;
                if (candidateMin.y < min.y) min.y = candidateMin.y;
                if (candidateMin.z < min.z) min.z = candidateMin.z;

                if (candidateMax.x > max.x) max.x = candidateMax.x;
                if (candidateMax.y > max.y) max.y = candidateMax.y;
                if (candidateMax.z > max.z) max.z = candidateMax.z;
                verticesCount += zone.VertexCount;
            }
            Transformation.Translate(-min.x, -min.y, -min.z);

            Vector3 v = max - min;
            Vector3 u = v * .5;

            Transformation.Translate(-u.x, -u.y, -u.z);

            if (v.x == 0) v.x = double.MinValue;
            if (v.y == 0) v.y = double.MinValue;
            if (v.z == 0) v.z = double.MinValue;

            v.x = Math.Max(v.x, v.y);
            v.x = Math.Max(v.x, v.z);
            v.x = size / v.x;

            Transformation.Scale(v.x, v.x, v.x);

            originalTransformation = Transformation.Clone();
        }

        private void ResetBounds()
        {
            minimumBounds?.Clear();
            maximumBounds?.Clear();
        }
    }
}