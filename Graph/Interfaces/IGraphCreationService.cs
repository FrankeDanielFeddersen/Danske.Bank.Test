using System.Collections.Generic;
using Graph.Entities;

namespace Graph.Interfaces
{
    public interface IGraphCreationService
    {
        Dictionary<int, Vertex> CreateVertex(int[] values);
        List<Vertex> CreateEdges(Dictionary<int, Vertex> vertices);
    }
}