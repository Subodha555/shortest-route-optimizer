// See https://aka.ms/new-console-template for more information
using ShortestPathLibrary;
using ShortestPathLibrary.Services;
using System;
using System.Collections.Generic;

namespace ShortestPathConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ShortestPathService = new ShortestPathService();
            var graph = GraphBuilder.BuildGraph();

            Console.WriteLine("Enter the starting node:");
            var fromNode = Console.ReadLine();

            Console.WriteLine("Enter the destination node:");
            var toNode = Console.ReadLine();

            var result = ShortestPathService.CalculateShortestPath(fromNode, toNode, graph);

            Console.WriteLine($"Shortest path: {string.Join(", ", result.NodeNames)}");
            Console.WriteLine($"Total distance: {result.Distance}");
        }
    }
}