using System;
using System.Collections.Generic;
using Veri_Yapilari_CS.Agac;
using Veri_Yapilari_CS.Heap;

/*
 * Kapsama Ağacı Nedir?
 * Çizgenin tüm vertexlerini içeren ağaca kapsama ağacı denir.
 * 
 * Minimum Kapsama Ağacı Nedir?
 * Kenarların maliyetlerinin toplamı en az olan kapsama ağacına denir.
 * 
 * Prims Algoritması Nedir?
 * Çizgeden minimum kapsama ağacı üretir.
 * Bir başlangıç vertexi belirlenir.
 * O vertexten gidebileceği kenarları ve maliyetlerini not alır.
 * En az maliyetli olana gider.
 * Yeni düğümün kenarlarını nota ekler.
 * Düğümler bitene kadar, bu işleme devam eder.
 * 
 */

namespace Veri_Yapilari_CS.Graph
{
    public partial class Graph<T>
    {

        public Agac<T> PrimsAlgorithm(T root)
        {
            // Döndürülecek Ağaç
            Agac<T> agac = new Agac<T>();
            agac.Root = new AgacNode<T>(root);

            // Graphta Kontrol Edilen Vertexler
            HashSet<T> visited = new HashSet<T>();
            visited.Add(root);

            // Gidilebilecek Vertexler, Vertexlerin Ağaçtaki Parentları ve Maliyetleri
            MinHeap<MSTEdge> minHeap = new MinHeap<MSTEdge>();
            foreach (var vertex in Vertices[root].OutEdges)
                minHeap.Add(new MSTEdge(agac.Root, vertex.Key.Key, vertex.Value));

            while (minHeap.Count > 0)
            {
                var mstEdge = minHeap.Delete();
                var parentNode = mstEdge.SourceKey;
                var currentKey = mstEdge.TargetKey;

                // Daha önce o vertexe bakıldı
                if (visited.Contains(currentKey)) continue;
                // Bakılmadıysa Şimdi Bakıldı
                visited.Add(currentKey);

                // Ağaca Ekle
                var newNode = new AgacNode<T>(currentKey);
                parentNode.Children.Add(newNode);

                // Kenarlarını Listeye Ekle
                foreach (var vertex in Vertices[currentKey].OutEdges)
                {
                    if (visited.Contains(vertex.Key.Key)) continue;

                    minHeap.Add(new MSTEdge(newNode, vertex.Key.Key, vertex.Value));
                }

            }

            return agac;
        }

        private class MSTEdge : IComparable<MSTEdge>
        {
            public AgacNode<T> SourceKey { get; private set; }
            public T TargetKey { get; private set; }
            public float Weight { get; private set; }

            public MSTEdge(AgacNode<T> sourceKey, T targetKey, float weight)
            {
                SourceKey = sourceKey;
                TargetKey = targetKey;
                Weight = weight;
            }
            public int CompareTo(MSTEdge other)
            {
                return Weight.CompareTo(other.Weight);
            }
        }
    }
}
