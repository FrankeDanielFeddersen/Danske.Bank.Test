using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    class ResultDTO
    {
        public int Sum { get; }
        public List<int> Path { get; }

        public ResultDTO(int sum, List<int> path)
        {
            Sum = sum;
            Path = path;
        }

        public override string ToString()
        {
            return string.Join(" --> ", Path);
        }
    }
}
