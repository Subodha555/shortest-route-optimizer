using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using ShortestPathLibrary.Models;

namespace ShortestPathLibrary.Services
{
   public class ShortestPathService
    {
        private readonly DijkstraAlgorithm _dijkstraAlgorithm;

        public ShortestPathService()
        {
            _dijkstraAlgorithm = new DijkstraAlgorithm();
        }

        public ShortestPathData CalculateShortestPath(string fromNode, string toNode, List<Node> graph)
        {
            return _dijkstraAlgorithm.ShortestPath(fromNode, toNode, graph);
        }
    }

    public class ShortestPathData
    {
        public List<string> NodeNames { get; set; }
        public int Distance { get; set; }
    }
}