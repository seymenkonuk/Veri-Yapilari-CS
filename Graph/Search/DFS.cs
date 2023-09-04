using System;
using System.Collections.Generic;

/*
 * Derinlik Öncelikli Arama Nedir?
 * Ağaçlardaki pre order traversal'a benzer mantıkla çalışır.
 * Kökten gidebileceği bir vertexe gider.
 * Daha sonra o vertexten gidebileceği vertexe gider.
 * Gidebileceği bir yer kalmazsa geldiği yere döner oradan diğer vertexlere gitmeye devam eder.
 */

namespace Veri_Yapilari_CS.Graph
{
    public partial class Graph<T>
    {
        public bool DepthFirstSearch(T root, T search)
        {
            return DepthFirst(root, search, new HashSet<T>(), false);
        }

        public void DepthFirstTraversal(T root)
        {
            DepthFirst(root, default, new HashSet<T>(), true);
        }
        private bool DepthFirst(T current, T search, HashSet<T> visited, bool traversal)
        {
            visited.Add(current);

            if (traversal)
                Console.WriteLine(current);
            // Aranan Bulundu
            else if (current.Equals(search)) return true;

            foreach (var vertex in Vertices[current].OutEdges.Keys)
            {
                // O vertexe daha önce bakıldı
                if (visited.Contains(vertex.Key)) continue;

                // O vertexe bak
                if (DepthFirst(vertex.Key, search, visited, traversal))
                    return true;
            }

            return false;
        }
    }
}
