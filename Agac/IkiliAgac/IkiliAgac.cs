using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veri_Yapilari_CS.Kuyruk;
using Veri_Yapilari_CS.Liste;

namespace Veri_Yapilari_CS.Agac.IkiliAgac
{
    public class IkiliAgac<T> : IEnumerable<T>
    {
        public IkiliAgacNode<T> Root { get; set; }

        // Recursive Dolaşma
        public Liste<IkiliAgacNode<T>> InOrder(IkiliAgacNode<T> root)
        {
            Liste<IkiliAgacNode<T>> sonuc = new Liste<IkiliAgacNode<T>>();
            InOrder(root, sonuc);
            return sonuc;
        }
        public Liste<IkiliAgacNode<T>> InOrder() => InOrder(Root);
        public Liste<IkiliAgacNode<T>> PreOrder(IkiliAgacNode<T> root)
        {
            Liste<IkiliAgacNode<T>> sonuc = new Liste<IkiliAgacNode<T>>();
            PreOrder(root, sonuc);
            return sonuc;
        }
        public Liste<IkiliAgacNode<T>> PreOrder() => PreOrder(Root); 
        public Liste<IkiliAgacNode<T>> PostOrder(IkiliAgacNode<T> root)
        {
            Liste<IkiliAgacNode<T>> sonuc = new Liste<IkiliAgacNode<T>>();
            PostOrder(root, sonuc);
            return sonuc;
        }
        public Liste<IkiliAgacNode<T>> PostOrder() => PostOrder(Root);
        private void InOrder(IkiliAgacNode<T> root, Liste<IkiliAgacNode<T>> sonuc) 
        {
            if (root != null) 
            { 
                InOrder(root.Left, sonuc);
                sonuc.Add(root);
                InOrder(root.Right, sonuc);
            }
        }
        private void PreOrder(IkiliAgacNode<T> root, Liste<IkiliAgacNode<T>> sonuc)
        {
            if (root != null)
            {
                sonuc.Add(root);
                PreOrder(root.Left, sonuc);
                PreOrder(root.Right, sonuc);
            }
        }
        private void PostOrder(IkiliAgacNode<T> root, Liste<IkiliAgacNode<T>> sonuc)
        {
            if (root != null)
            {
                PostOrder(root.Left, sonuc);
                PostOrder(root.Right, sonuc);
                sonuc.Add(root);
            }
        }

        // Non-Recursive Dolaşma
        public Liste<IkiliAgacNode<T>> LevelOrder(IkiliAgacNode<T> root)
        {
            Liste<IkiliAgacNode<T>> sonuc = new Liste<IkiliAgacNode<T>>();
            Kuyruk<IkiliAgacNode<T>> sira = new Kuyruk<IkiliAgacNode<T>>();
            sira.EnQueue(root);

            while (sira.Count > 0)
            {
                var current = sira.DeQueue();
                sonuc.Add(current);
                if (current.Left != null)
                    sira.EnQueue(current.Left);
                if (current.Right != null)
                    sira.EnQueue(current.Right);
            }

            return sonuc;
        }
        public Liste<IkiliAgacNode<T>> LevelOrder() => LevelOrder(Root);

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in InOrder(Root))
                yield return item.Value;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
