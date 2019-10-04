using Graph.Entities;

namespace Graph
{
    public class Edge
    {
        public Vertex First { get; }
        public Vertex Second { get; }

        public Edge(Vertex first, Vertex second)
        {
            First = first;
            Second = second;
        }
    }
}
