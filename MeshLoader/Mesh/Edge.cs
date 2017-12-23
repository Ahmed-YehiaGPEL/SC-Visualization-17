namespace Visualization
{
    public class Edge
    {
        public uint Start;
        public uint End;

        public Edge() : this(0, 0)
        {
        }

        public Edge(uint st, uint end)
        {
            Start = st;
            End = end;
        }

        public void Set(uint st, uint end)
        {
            Start = st;
            End = end;
        }
    }
}