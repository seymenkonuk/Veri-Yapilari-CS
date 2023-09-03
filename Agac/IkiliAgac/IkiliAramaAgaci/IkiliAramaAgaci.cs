using System;
using System.Collections.Generic;
using Veri_Yapilari_CS.Liste;

namespace Veri_Yapilari_CS.Agac.IkiliAgac.IkiliAramaAgaci
{
    public class IkiliAramaAgaci<T> : IkiliAgac<T> where T : IComparable<T>
    {
        public IkiliAramaAgaci()
        {

        }
        public IkiliAramaAgaci(params T[] collection)
        {
            foreach (var item in collection)
                Add(item);
        }
        public IkiliAramaAgaci(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Add(item);
        }
        public void Add(T value)
        {
            var node = new IkiliAgacNode<T>(value);

            // Ağaç Boşsa
            if (Root == null)
            {
                Root = node;
                return;
            }
            var current = Root;
            while (true)
            {
                var parent = current;
                if (value.CompareTo(current.Value) <= 0)
                {
                    current = current.Left;
                    if (current == null)
                    {
                        parent.Left = node;
                        break;
                    }
                }
                else
                {
                    current = current.Right;
                    if (current == null)
                    {
                        parent.Right = node;
                        break;
                    }
                }
            }
        }
        public void Remove(IkiliAgacNode<T> root, T value)
        {
            var current = root;
            IkiliAgacNode<T> parent = null;
            // Silinecek Node ve Parentını Bul
            while (current != null)
            {
                if (value.CompareTo(current.Value) == 0)
                    break;
                parent = current;
                if (value.CompareTo(current.Value) < 0)
                    current = current.Left;
                else
                    current = current.Right;
            }

            // Öyle Bir ELeman Yok
            if (current == null)
                return;

            // Tek Elemanlı Bir Ağaç
            if (parent == null)
            {
                Root = null;
                return;
            }

            // O Elemanın Elemanları
            Liste<IkiliAgacNode<T>> liste = LevelOrder(current);
            liste.RemoveAt(0); // O elemanı sil

            // O Elemandan Sonraki Tüm Elemanlar ile Bağlantıyı Kopart
            if (parent.Left.Value.CompareTo(current.Value) == 0)
                parent.Left = null;
            else
                parent.Right = null;

            // O Eleman Hariç Gerisini Tekrar Ekle
            foreach (var item in liste)
                Add(item.Value);
        }
        public void Remove(T value) => Remove(Root, value);

        public T FindMin(IkiliAgacNode<T> root)
        {
            var current = root;
            while (current.Left != null)
                current = current.Left;
            return current.Value;
        }
        public T FindMax(IkiliAgacNode<T> root)
        {
            var current = root;
            while (current.Right != null)
                current = current.Right;
            return current.Value;
        }
        public T FindMin() => FindMin(Root);
        public T FindMax() => FindMax(Root);

        public IkiliAgacNode<T> Find(IkiliAgacNode<T> root, T value)
        {
            var current = root;
            while (current != null)
            {
                if (value.CompareTo(current.Value) == 0)
                    return current;
                if (value.CompareTo(current.Value) < 0)
                    current = current.Left;
                else
                    current = current.Right;
            }
            return null;
            // throw new Exception("Aranan eleman bulunamadı.");
        }
        public IkiliAgacNode<T> Find(T value) => Find(Root, value);
    }
}
