using Veri_Yapilari_CS.Agac;
using Veri_Yapilari_CS.AyrikSet;
using Veri_Yapilari_CS.Heap;
using Veri_Yapilari_CS.Kuyruk;
using Veri_Yapilari_CS.Liste;

/*
 * Kruskals Algoritması Nedir?
 * Çizgeden minimum kapsama ağacı üretir.
 * Graphtaki tüm kenarların listesi oluşturulur.
 * Kenarlardan en küçük olanın iki ucu (vertex) zaten birleşik değil ise birleştirilir.
 * Listedeki tüm kenarlar bittiğinde program biter.
 */

namespace Veri_Yapilari_CS.Graph
{
    public partial class Graph<T>
    {

        public Agac<T> KruskalsAlgorithm(T root)
        {
            // Tüm Kenarları Bul
            MinHeap<MSTEdge> kenarlar = new MinHeap<MSTEdge>();
            foreach (var vertex in Vertices)
            {
                var agacNode = new AgacNode<T>(vertex.Key);
                foreach (var komsuVertex in vertex.Value.OutEdges)
                    kenarlar.Add(new MSTEdge(agacNode, komsuVertex.Key.Key, komsuVertex.Value));
            }

            // Ayrık Set Oluştur
            AyrikSet<T> ayrikSet = new AyrikSet<T>();
            foreach (var vertex in Vertices)
                ayrikSet.MakeSet(vertex.Key);

            // Ağaçta Kullanılacak Kenarlar
            Liste<MSTEdge> sonucKenarlar = new Liste<MSTEdge>();

            // Kenarları Ayrık Sette Birleştir
            while (kenarlar.Count > 0)
            {
                var kenar = kenarlar.Delete();
                var sourceKey = kenar.SourceKey.Value;
                var targetKey = kenar.TargetKey;
                
                // Zaten Aynı Setteler
                if (ayrikSet.FindSet(sourceKey).Equals(ayrikSet.FindSet(targetKey)))
                    continue;

                sonucKenarlar.Add(kenar);
                ayrikSet.Union(targetKey, sourceKey);
            }

            // Kenarlara bakarak ağacı oluştur
            Agac<T> agac = new Agac<T>();
            agac.Root = new AgacNode<T>(root);

            Kuyruk<AgacNode<T>> agacDugumleri = new Kuyruk<AgacNode<T>>();
            agacDugumleri.EnQueue(agac.Root);

            while (agacDugumleri.Count > 0)
            {
                var currentNode = agacDugumleri.DeQueue();
                var currentKey = currentNode.Value;
                for (int i = 0; i < sonucKenarlar.Count; i++)
                {
                    var sourceKey = sonucKenarlar[i].SourceKey.Value;
                    var targetKey = sonucKenarlar[i].TargetKey;

                    // Bu kenar CurrentNode'un kenarı değilse ilerle
                    if (!currentKey.Equals(sourceKey) && !currentKey.Equals(targetKey)) 
                        continue;

                    // Doğru kenarsa ağaca ekle

                    // Ağaca Eklenecek Düğümün Değerini Bul
                    var childNodeKey = targetKey;
                    if (currentKey.Equals(targetKey))
                        childNodeKey = sourceKey;

                    var childNode = new AgacNode<T>(childNodeKey);
                    currentNode.Children.Add(childNode);
                    agacDugumleri.EnQueue(childNode);
                    
                    // Sonuç Kenarları Listesinden Çıkar
                    sonucKenarlar.RemoveAt(i);
                    i--;

                }
            }

            return agac;
        }

    }
}
