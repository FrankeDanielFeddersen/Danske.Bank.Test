using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    internal class Vertex<T>
    {
        private readonly List<Vertex<T>> _neighbors;
        private readonly List<WeightedEdge<T>> _edges;
        private T _value;

        public List<Vertex<T>> Neighbors => _neighbors;
        public List<WeightedEdge<T>> Edges => _edges;
        public T Value { get => _value;
            set => this._value = value;
        }
        public bool IsVisited { get; set; }
        public int NeighborsCount => _neighbors.Count;
        public double Cost { get; set; }

        public Vertex(T value)
        {
            this._value = value;
            IsVisited = false;
            _neighbors = new List<Vertex<T>>();
            _edges = new List<WeightedEdge<T>>();
        }

        public Vertex(T value, List<Vertex<T>> neighbors)
        {
            this._value = value;
            IsVisited = false;
            this._neighbors = neighbors;
        }

        public void AddNeighbor(Vertex<T> vertex)
        {
            _neighbors.Add(vertex);
        }
        public void AddEdge(WeightedEdge<T> edge)
        {
            _edges.Add(edge);
        }

        public override string ToString()
        {
            StringBuilder allNeighbors = new StringBuilder("");
            allNeighbors.Append(_value + ": ");

            foreach (Vertex<T> neighbor in _neighbors)
            {
                allNeighbors.Append(neighbor._value + "  ");
            }

            return allNeighbors.ToString();
        }

    }
}