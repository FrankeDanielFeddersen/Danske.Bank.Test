using System.Collections.Generic;
using System.Linq;
using Graph.Entities;
using Graph.Interfaces;

namespace Graph.Service
{
    public class GraphCreationService : IGraphCreationService
    {
        private const int IndexCount = 1;

        public Dictionary<int, Vertex> CreateVertex(int[] values)
        {
            var vertices = new Dictionary<int, Vertex>();

            for (var i = 0; i < values.Length; i++)
            {
                vertices.Add(i, new Vertex(i, values[i]));
            }

            return vertices;
        }

        public List<Vertex> CreateEdges(Dictionary<int, Vertex> vertices)
        {
            var root = vertices[0];
            var pyramidLevel = 1;
            var maxLevel = CalcMaxLevel(vertices.Count);
            var verticeCounter = 0;

            for (var i = 0; i < vertices.Count; i++)
            {
                var currentVertex = vertices[i];

                if (pyramidLevel > maxLevel)
                    break;


                if (i == 0)
                {
                    var nextVertex = vertices[i + 1];
                    var nextVertex1 = vertices[i + 2];

                    root.AddEdge(new Edge(currentVertex, nextVertex));
                    root.AddEdge(new Edge(currentVertex, nextVertex1));
                    verticeCounter++;
                    pyramidLevel++;
                }

                else
                {
                    CreateEdge(currentVertex, vertices, verticeCounter, pyramidLevel);
                    verticeCounter++;

                    if (ShouldIncrementLevel(pyramidLevel, verticeCounter))
                        pyramidLevel++;
                }
            }

            return vertices.Select(x => x.Value).ToList();
        }

        private static bool ShouldIncrementLevel(int level, int counter)
        {
            var sum = 0;
            for (int i = level; i > 0; i--)
            {
                sum += i;
            }

            return counter >= sum;
        }

        private static int CalcMaxLevel(int verticesCount)
        {
            var level = 1;
            var counter = 1;

            while (true)
            {
                if (counter.Equals(verticesCount))
                {
                    return level - 1;
                }
                else
                {
                    level++;
                    counter += level;
                }
            }
        }

        private void CreateEdge(Vertex currentVertex, Dictionary<int, Vertex> vertices, int verticeCounter, int level)
        {
            var i = IndexCount + level + verticeCounter;
            var firstVertex = vertices[i - IndexCount];
            var secondVertex = vertices[i];

            currentVertex.AddEdge(new Edge(currentVertex, firstVertex));
            currentVertex.AddEdge(new Edge(currentVertex, secondVertex));
        }
    }
}
