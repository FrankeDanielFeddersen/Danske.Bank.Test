namespace TestApp
{
    class WeightedEdge<T>
    {
        readonly int _weight;

        readonly Vertex<T> _start;
        readonly Vertex<T> _end;

        public int Weight => _weight;

        public Vertex<T> Start => _start;
        public Vertex<T> End => _end;

        public WeightedEdge(Vertex<T> start, Vertex<T> end, int weight)
        {
            this._start = start;
            this._end = end;
            this._weight = weight;
            start.AddNeighbor(end);
            start.AddEdge(this);
        }

        public override string ToString()
        {
            return $"{_start.Value}--{_weight}-->{_end.Value}";
        }
    }
}