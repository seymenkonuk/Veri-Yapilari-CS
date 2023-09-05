using System;
using System.Collections.Generic;
using Veri_Yapilari_CS.Heap;

/*
 * Sabit Maliyetli Arama Nedir?
 * yayılım öncelikli arama ile bir miktar benzerlikleri vardır.
 * Bir vertexe geldiğinde oradan gidebileceği tüm vertexleri bir yerde saklar.
 * Ve bu sakladığı yerdeki en az maliyetli olan vertexe gider.
 * Bu vertexe geldiğinde yine bu sakladığı yere yeni vertexler ekler.
 * Ve tekrar en az maliyetli olana gider.
 */

namespace Veri_Yapilari_CS.Graph
{
    public partial class Graph<T>
    {
        public bool UniformedCostSearch(T root, T search)
        {
            return UniformedCost(root, search, false);
        }

        public void UniformedCostTraversal(T root)
        {
            UniformedCost(root, default, true);
        }
        public bool UniformedCost(T root, T search, bool traversal)
        {
            HashSet<T> visited = new HashSet<T>();
            MinHeap<Edge> minHeap = new MinHeap<Edge>();
            minHeap.Add(new Edge(root, 0));

            while (minHeap.Count > 0)
            {
                var edge = minHeap.Delete();
                var currentWeight = edge.Weight;
                var currentKey = edge.TargetKey;

                // Daha önce o vertexe bakıldı
                if (visited.Contains(currentKey)) continue;
                // Bakılmadıysa Şimdi Bakıldı
                visited.Add(currentKey);

                if (traversal)
                    Console.WriteLine(currentKey);
                // Aranan Bulundu
                else if (currentKey.Equals(search)) return true;

                // Kenarlarını Minheape Ekle
                foreach (var vertex in Vertices[currentKey].OutEdges)
                {
                    if (visited.Contains(vertex.Key.Key)) continue;

                    var newEdge = new Edge(vertex.Key.Key, currentWeight + vertex.Value);
                    minHeap.Add(newEdge);
                }
            }

            return false;
        }

        private class Edge : IComparable<Edge>
        {
            public T TargetKey {get; private set; }
            public float Weight { get; private set; }

            public Edge(T targetKey, float weight)
            {
                TargetKey = targetKey; 
                Weight = weight;
            }
            public int CompareTo(Edge other)
            {
                return Weight.CompareTo(other.Weight);
            }
        }
    }
}
