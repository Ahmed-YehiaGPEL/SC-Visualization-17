namespace Visualization
{
    namespace DataStructures
    {
        internal class Node
        {
            public object Data;
            public Node Next;

            public Node(object data) : this(data, null)
            {
            }

            public Node(object data, Node next)
            {
                Data = data;
                Next = next;
            }
        }
    }
}