using System.Collections.Generic;
using System.Linq;
using Graph.Entities;
using Graph.Interfaces;

namespace Graph.Service
{
    internal class GraphService : IGraphService
    {
        private List<Vertex> Vertices { get; }
        private readonly Queue<Vertex> queuePath;
        private List<Vertex> VerticesPath;
        public GraphService(List<Vertex> vertices)
        {
            Vertices = vertices;
            queuePath = new Queue<Vertex>();
            VerticesPath = new List<Vertex>();
        }

        public ResultDTO FindBiggestSum()
        {
            InitCalculation();

            while (queuePath.TryDequeue(out var vertex))
            {
                if(vertex.Edges.Count.Equals(0))
                    break;

                AddBiggestVertex(vertex);
            }

            var result = CalculatePath();

            return result;
        }

        private void InitCalculation()
        {
            var firstVertex = Vertices.FirstOrDefault();

            queuePath.Enqueue(firstVertex);
            VerticesPath.Add(firstVertex);
        }

        private ResultDTO CalculatePath()
        {
            var path = new List<int>();
            var combinedValue = 0;

            foreach (var vertex in VerticesPath)
            {
                path.Add(vertex.Value);
                combinedValue += vertex.Value;
            }

           var dto = new ResultDTO(combinedValue, path);

           return dto;
        }

        private void AddBiggestVertex(Vertex currentVertex)
        {
            var isEven = currentVertex.IsEven();
            Vertex biggestVertexValue = null;
            foreach (var currentVertexEdge in currentVertex.Edges)
            {
                var vertex = currentVertexEdge.Second;
                if (isEven.Equals(vertex.IsEven()))
                    continue;

                if (biggestVertexValue == null)
                    biggestVertexValue = vertex;

                if (biggestVertexValue.Value < vertex.Value)
                    biggestVertexValue = vertex;
            }

            queuePath.Enqueue(biggestVertexValue);
            VerticesPath.Add(biggestVertexValue);
        }
    }
}
