using Visualization.Mathf;

namespace Visualization
{
    public class Vertex
    {
        /// <summary>
        /// The position of the vertex in 3D space
        /// </summary>
        public Point3 Position;
        /// <summary>
        /// Extra data values associated with vertex
        /// </summary>
        public double[] Data;

        public Vertex()
        {
            Position = new Point3();
            Data = null;
        }

        public Vertex(
            ref double x,
            ref double y,
            ref double z,
            uint cData)
        {
            Position = new Point3(ref x, ref y, ref z);
            if (cData == 0) Data = null;
            else Data = new double[cData];
        }

        public void SetPosition(
            ref double x,
            ref double y,
            ref double z)
        {
            Position.Set(ref x, ref y, ref z);
        }

        public override string ToString()
        {
            string retval = string.Format("Position: {0} | Data:", Position.ToString());
            for (int i = 0; i < Data.Length; i++)
                retval += " " + Data[i].ToString();
            return retval;
        }
    }
}