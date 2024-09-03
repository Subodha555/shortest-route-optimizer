using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShortestPathLibrary.Models;

namespace ShortestPathLibrary
{
    public class GraphBuilder
    {
        public static List<Node> BuildGraph()
        {
            var nodes = new Dictionary<string, Node>
            {
                { "A", new Node("A") },
                { "B", new Node("B") },
                { "C", new Node("C") },
                { "D", new Node("D") },
                { "E", new Node("E") },
                { "F", new Node("F") },
                { "G", new Node("G") },
                { "H", new Node("H") },
                { "I", new Node("I") }
            };

            nodes["A"].AddEdge(nodes["B"], 4);
            nodes["A"].AddEdge(nodes["C"], 6);

            nodes["B"].AddEdge(nodes["F"], 2);
            nodes["B"].AddEdge(nodes["A"], 4);

            nodes["C"].AddEdge(nodes["D"], 8);
            nodes["C"].AddEdge(nodes["A"], 6);

            nodes["D"].AddEdge(nodes["E"], 4);
            nodes["D"].AddEdge(nodes["G"], 1);
            nodes["D"].AddEdge(nodes["C"], 8);

            nodes["E"].AddEdge(nodes["B"], 2);
            nodes["E"].AddEdge(nodes["F"], 3);
            nodes["E"].AddEdge(nodes["I"], 8);
            nodes["E"].AddEdge(nodes["D"], 4);

            nodes["F"].AddEdge(nodes["H"], 6);
            nodes["F"].AddEdge(nodes["B"], 2);
            nodes["F"].AddEdge(nodes["E"], 3);
            nodes["F"].AddEdge(nodes["G"], 4);

            nodes["G"].AddEdge(nodes["H"], 5);
            nodes["G"].AddEdge(nodes["I"], 5);
            nodes["G"].AddEdge(nodes["D"], 1);
            nodes["G"].AddEdge(nodes["F"], 4);

            nodes["H"].AddEdge(nodes["G"], 5);
            nodes["H"].AddEdge(nodes["F"], 6);

            nodes["I"].AddEdge(nodes["E"], 8);
            nodes["I"].AddEdge(nodes["G"], 5);

            return new List<Node>(nodes.Values);
        }
    }
}