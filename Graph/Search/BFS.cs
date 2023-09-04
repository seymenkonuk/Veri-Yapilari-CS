using System;
using System.Collections.Generic;
using Veri_Yapilari_CS.Kuyruk;

/*
 * Yayılım Öncelikli Arama Nedir?
 * Ağaçlardaki level order traversal'a benzer mantıkla çalışır.
 * Önce köke 1 uzaklıktaki vertexleri
 * Daha sonra köke 2 uzaklıktaki vertexleri
 * En son köke n uzaklıktaki vertexleri
 * dolaşır.
 */

namespace Veri_Yapilari_CS.Graph
{
    public partial class Graph<T>
    {

        public bool BreadthFirstSearch(T root, T search)
        {
            return BreadthFirst(root, search, false);
        }

        public void BreadthFirstTraversal(T root)
        {
            BreadthFirst(root, default, true);
        }

        public bool BreadthFirst(T root, T search, bool traversal)
        {
            HashSet<T> visited = new HashSet<T>();
            Kuyruk<T> kuyruk = new Kuyruk<T>();
            kuyruk.EnQueue(root);
            visited.Add(root);

            while (kuyruk.Count > 0)
            {
                var currentKey = kuyruk.DeQueue();

                if (traversal)
                    Console.WriteLine(currentKey);

                // Aranan Bulundu
                else if (currentKey.Equals(search)) return true;

                // Kenarlarını Kuyruğa Ekle
                foreach (var vertex in Vertices[currentKey].OutEdges.Keys)
                {
                    // Daha önce o vertexe bakıldı
                    if (visited.Contains(vertex.Key)) continue;
                    // Bakılmadıysa Birazdah Bakılacak
                    visited.Add(vertex.Key);

                    kuyruk.EnQueue(vertex.Key);
                }
            }

            return false;
        }
    }
}
