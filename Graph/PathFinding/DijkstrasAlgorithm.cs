using System;
using Veri_Yapilari_CS.BagliListe;
using Veri_Yapilari_CS.Heap;
using Veri_Yapilari_CS.Liste;
using Veri_Yapilari_CS.Sozluk;

/*
 * Dijkstra's Algoritması Nedir?
 * Graphtaki bir düğümden diğer tüm düğümlere olan
 * en kısa yolu bulmayı amaçlayan bir algoritmadır.
 */

namespace Veri_Yapilari_CS.Graph
{
    public partial class Graph<T>
    {
        public Liste<T> RotaGoster(T root, T search)
        {
            BagliListe<T> rota = new BagliListe<T>();

            Sozluk<T, T> dijkstra = DijkstrasAlgorithm(root);

            if (!dijkstra.ContainsKey(search))
                throw new Exception("İki vertex arasında yol bulunamadı.");

            T current = search;
            while (true)
            {
                rota.AddFirst(current);
                if (current.Equals(root))
                    break;
                current = dijkstra[current];
            }

            return new Liste<T>(rota);
        }
        public Sozluk<T, T> DijkstrasAlgorithm(T root)
        {
            // Geriye Döndürülecek Sonuç
            // ilk T : gitmek istediğimiz yer
            // ikinci T : oraya gitmek için gitmemiz gereken yer
            Sozluk<T, T> sonuc = new Sozluk<T, T>();

            // Geçici Depolamak ve En Kısayı Bulmak için
            MinHeap<Rota> rotalar = new MinHeap<Rota>();
            rotalar.Add(new Rota(root, root, 0));

            while (rotalar.Count > 0)
            {
                var current = rotalar.Delete();

                // Zaten O Rota Bulundu
                if (sonuc.ContainsKey(current.Key)) continue;

                // Sonuca Ekle
                sonuc.Add(current.Key, current.ParentKey);

                // Kenarlarını Dolaş
                foreach (var vertex in Vertices[current.Key].OutEdges)
                {
                    // O vertexin rotası zaten bulundu
                    if (sonuc.ContainsKey(vertex.Key.Key))
                        continue;

                    rotalar.Add(new Rota(vertex.Key.Key, current.Key, current.Maliyet + vertex.Value));
                }

            }

            return sonuc;
        }

        private class Rota : IComparable<Rota>
        {
            public T Key {  get; set; }
            public T ParentKey { get; set; }
            public float Maliyet { get; set; }

            public Rota(T key, T parentKey, float maliyet)
            {
                Key = key;
                ParentKey = parentKey;
                Maliyet = maliyet;
            }

            public int CompareTo(Rota other)
            {
                return Maliyet.CompareTo(other.Maliyet);
            }
        }
    }
}
