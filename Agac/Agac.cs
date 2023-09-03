using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veri_Yapilari_CS.Kuyruk;
using Veri_Yapilari_CS.Liste;

namespace Veri_Yapilari_CS.Agac
{
    internal class Agac<T>
    {
        public AgacNode<T> Root { get; set; }
        public Liste<AgacNode<T>> GetNodes(AgacNode<T> root)
        {
            Liste<AgacNode<T>> nodes = new Liste<AgacNode<T>>();
            Kuyruk<AgacNode<T>> sira = new Kuyruk<AgacNode<T>>();
            sira.EnQueue(root);

            while (sira.Count > 0)
            {
                root = sira.DeQueue();
                nodes.Add(root);
                foreach (var child in root.Children)
                    sira.EnQueue(child);
            }

            return nodes;
        }
        public Liste<AgacNode<T>> GetNodes() => GetNodes(Root);
    }
}
