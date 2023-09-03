using System;
using System.Collections;
using System.Collections.Generic;

namespace Veri_Yapilari_CS.BagliListe
{
    public class BagliListe<T> : IEnumerable<T>
    {
        public BagliListeNode<T> Head;
        public BagliListeNode<T> Tail;
        public int Count { get; private set; }

        public BagliListe()
        {
            
        }
        public BagliListe(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                AddLast(item);
        }

        public void AddBefore(BagliListeNode<T> node,  T value)
        {
            BagliListeNode<T> yeniNode = new BagliListeNode<T>(value); 
            yeniNode.Prev = node.Prev;
            yeniNode.Next = node;
            if (node.Prev == null)
                Head = yeniNode;
            else
                node.Prev.Next = yeniNode;
            node.Prev = yeniNode;
            Count++;
        }
        public void AddAfter(BagliListeNode<T> node, T value)
        {
            BagliListeNode<T> yeniNode = new BagliListeNode<T>(value);
            yeniNode.Prev = node;
            yeniNode.Next = node.Next;
            if (node.Next == null)
                Tail = yeniNode;
            else
                node.Next.Prev = yeniNode;
            node.Next = yeniNode;
            Count++;
        }
        public void AddFirst(T value)
        {
            if (Head == null)
            {
                Head = new BagliListeNode<T>(value);
                Tail = Head;
                Count++;
            } else
                AddBefore(Head, value);
        }
        public void AddLast(T value)
        {
            if (Tail == null)
            {
                Head = new BagliListeNode<T>(value);
                Tail = Head;
                Count++;
            }
            else
                AddAfter(Tail, value);
        }
        public T RemoveLast()
        {
            if (Count == 0)
                throw new Exception("Eleman Yok!");
            Count--;

            // Tek Düğüm Var ise
            T sonuc = Tail.Value;
            if (Tail.Prev == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Prev.Next = null;
                Tail = Tail.Prev;
            }
            return sonuc;
        }
        public T RemoveFirst()
        {
            if (Count == 0)
                throw new Exception("Eleman Yok!");
            Count--;

            // Tek Düğüm Var ise
            T sonuc = Head.Value;
            if (Head.Next == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head.Next.Prev = null;
                Head = Head.Next;
            }
            return sonuc;
        }
        public bool Remove(T value)
        {
            var node = GetNode(value);
            if (node == null)
                return false;
            // Silme İşlemi
            if (node.Prev == null)
                Head = node.Next;
            else
                node.Prev.Next = node.Next;

            if (node.Next == null)
                Tail = node.Prev;
            else
                node.Next.Prev = node.Prev;
            Count--;
            return true;
        }
        public void Clear()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }
        public bool Contains(T item) => GetNode(item) != null;
        
        public BagliListeNode<T> GetNode(T value)
        {
            BagliListeNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return current;
                current = current.Next;
            }
            return null;
        }
        public IEnumerator<T> GetEnumerator()
        {
            BagliListeNode<T> current = Head;
            while (current != null) {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
