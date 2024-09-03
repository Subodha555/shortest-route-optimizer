using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortestPathLibrary.Models
{
    public class Node
    {
        public string Name { get; }
        public List<Edge> Edges { get; }

        public Node(string name)
        {
            Name = name;
            Edges = new List<Edge>();
        }

        public void AddEdge(Node toNode, int weight)
        {
            Edges.Add(new Edge(this, toNode, weight));
        }
    }

    public class Edge
    {
        public Node FromNode { get; }
        public Node ToNode { get; }
        public int Weight { get; }

        public Edge(Node fromNode, Node toNode, int weight)
        {
            FromNode = fromNode;
            ToNode = toNode;
            Weight = weight;
        }
    }
}