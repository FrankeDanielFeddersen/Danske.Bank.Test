using System.Collections.Generic;

namespace Graph.Entities
{
    public class Vertex
    {
        public int Index { get; }
        public int Value { get; }
        public List<Edge> Edges { get; private set; }
        public bool Visited { get; set; }

        public Vertex(int index, int value)
        {
            Index = index;
            Value = value;
            Edges = new List<Edge>();
            Visited = false;
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public bool IsEven()
        {
            return Value % 2 == 0;
        }
    }
}
