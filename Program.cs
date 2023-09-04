using System;
using System.Net.WebSockets;
using Veri_Yapilari_CS.Graph;

namespace Veri_Yapilari_CS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();

            // Düğümleri Ekle
            graph.AddVertex(0); 
            graph.AddVertex(1); 
            graph.AddVertex(2); 
            graph.AddVertex(3); 
            graph.AddVertex(4); 
            graph.AddVertex(5); 
            graph.AddVertex(6); 
            graph.AddVertex(7); 
            graph.AddVertex(8);

            // Kenarları Ekle
            graph.AddEdge(0, 8, 4);
            graph.AddEdge(0, 3, 2);
            graph.AddEdge(3, 4, 1);
            graph.AddEdge(3, 2, 6);
            graph.AddEdge(1, 0, 3);
            graph.AddEdge(2, 7, 2);
            graph.AddEdge(7, 1, 4);
            graph.AddEdge(6, 5, 8);
            graph.AddEdge(8, 4, 8);
            graph.AddEdge(2, 5, 1);

            Console.WriteLine(graph.DepthFirstSearch(8, 5));
            graph.DepthFirstTraversal(8);
            Console.WriteLine(graph.BreadthFirstSearch(8, 5));
            graph.BreadthFirstTraversal(8);
            Console.WriteLine(graph.UniformedCostSearch(8, 5));
            graph.UniformedCostTraversal(8);

            Console.ReadKey();
        }
    }
}