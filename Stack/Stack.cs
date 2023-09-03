using System;
using Veri_Yapilari_CS.BagliListe;

namespace Veri_Yapilari_CS.Stack
{
    public class Stack<T>
    {
        private readonly BagliListe<T> liste = new BagliListe<T>();
        public int Count => liste.Count;

        public void Push(T value)
        {
            liste.AddLast(value);
        }

        public void Clear()
        {
            liste.Clear();
        }

        public T Peek()
        {
            if (Count == 0)
                throw new Exception("Eleman Yok!");
            return liste.Tail.Value;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new Exception("Eleman Yok!");
            T sonuc = Peek();
            liste.RemoveLast();
            return sonuc;
        }
    }
}
