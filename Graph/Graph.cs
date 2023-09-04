using System;
using Veri_Yapilari_CS.Sozluk;

namespace Veri_Yapilari_CS.Graph
{
    public partial class Graph<T>
    {
        public Sozluk<T, GraphVertex<T>> Vertices { get; private set; } = new Sozluk<T, GraphVertex<T>>();

        public void AddVertex(T key)
        {
            if (Vertices.ContainsKey(key)) throw new Exception("Bu vertex zaten mevcut.");
            Vertices.Add(key, new GraphVertex<T>(key));
        }

        public void RemoveVertex(T key)
        {
            if (!Vertices.ContainsKey(key)) throw new Exception("İlgili vertex bulunamadı.");

            // Kenarlarını Sil
            foreach (var vertex in Vertices[key].InEdges.Keys)
                vertex.OutEdges.Remove(Vertices[key]);

            foreach (var vertex in Vertices[key].OutEdges.Keys)
                vertex.InEdges.Remove(Vertices[key]);

            Vertices.Remove(key);
        }

        public void AddDiEdge(T baslangic, T bitis, float weight = default)
        {
            if (!Vertices.ContainsKey(baslangic)) throw new Exception("İlgili vertex bulunamadı.");
            if (!Vertices.ContainsKey(bitis)) throw new Exception("İlgili vertex bulunamadı.");

            if (Vertices[baslangic].OutEdges.ContainsKey(Vertices[bitis])) throw new Exception("Kenar zaten var.");
            if (Vertices[bitis].InEdges.ContainsKey(Vertices[baslangic])) throw new Exception("Kenar zaten var.");

            Vertices[baslangic].OutEdges.Add(Vertices[bitis], weight);
            Vertices[bitis].InEdges.Add(Vertices[baslangic], weight);
        }

        public void AddEdge(T key1, T key2, float weight = default)
        {
            AddDiEdge(key1, key2, weight);
            AddDiEdge(key2, key1, weight);
        }

        public void RemoveDiEdge(T baslangic, T bitis)
        {
            if (!Vertices.ContainsKey(baslangic)) throw new Exception("İlgili vertex bulunamadı.");
            if (!Vertices.ContainsKey(bitis)) throw new Exception("İlgili vertex bulunamadı.");

            if (!Vertices[baslangic].OutEdges.ContainsKey(Vertices[bitis])) throw new Exception("Kenar bulunamadı.");
            if (!Vertices[bitis].InEdges.ContainsKey(Vertices[baslangic])) throw new Exception("Kenar bulunamadı.");

            Vertices[baslangic].OutEdges.Remove(Vertices[bitis]);
            Vertices[bitis].InEdges.Remove(Vertices[baslangic]);
        }

        public void RemoveEdge(T key1, T key2)
        {
            RemoveDiEdge(key1, key2);
            RemoveDiEdge(key2, key1);
        }
    }
}
