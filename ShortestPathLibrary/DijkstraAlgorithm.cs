using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShortestPathLibrary.Models;
using ShortestPathLibrary.Services;

namespace ShortestPathLibrary
{
    public class DijkstraAlgorithm
    {
        public ShortestPathData ShortestPath(string startNodeName, string endNodeName, List<Node> graph)
        {
            var startNode = graph.FirstOrDefault(node => node.Name == startNodeName);
            var endNode = graph.FirstOrDefault(node => node.Name == endNodeName);

            if (startNode == null || endNode == null)
            {
                throw new ArgumentException("Start or end node not found in the graph.");
            }

            var distances = new Dictionary<Node, int>();
            var previousNodes = new Dictionary<Node, Node>();
            var unvisitedNodes = new HashSet<Node>(graph);

            // Initialize distances and previous nodes
            foreach (var node in graph)
            {
                distances[node] = int.MaxValue;
                previousNodes[node] = null;
            }

            distances[startNode] = 0;

            while (unvisitedNodes.Count > 0)
            {
                // Get the node with the smallest distance
                var currentNode = unvisitedNodes.OrderBy(node => distances[node]).First();
                unvisitedNodes.Remove(currentNode);

                // If we reached the end node, stop the algorithm
                if (currentNode == endNode)
                {
                    break;
                }

                foreach (var edge in currentNode.Edges)
                {
                    var neighbor = edge.ToNode;
                    if (!unvisitedNodes.Contains(neighbor)) continue;

                    var tentativeDistance = distances[currentNode] + edge.Weight;
                    if (tentativeDistance < distances[neighbor])
                    {
                        distances[neighbor] = tentativeDistance;
                        previousNodes[neighbor] = currentNode;
                    }
                }
            }

            // Build the shortest path
            var path = new List<Node>();
            var current = endNode;

            while (current != null)
            {
                path.Insert(0, current);
                current = previousNodes[current];
            }

            return new ShortestPathData
            {
                NodeNames = path.Select(node => node.Name).ToList(),
                Distance = distances[endNode]
            };
        }
    }

    // public class ShortestPathData
    // {
    //     public List<string> NodeNames { get; set; }
    //     public int Distance { get; set; }
    // }
}