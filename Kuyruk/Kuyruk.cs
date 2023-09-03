using System;
using Veri_Yapilari_CS.BagliListe;

namespace Veri_Yapilari_CS.Kuyruk
{
    public class Kuyruk<T>
    {
        private readonly BagliListe<T> liste = new BagliListe<T>();
        public int Count => liste.Count;

        public void EnQueue(T value)
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
            return liste.Head.Value;
        }

        public T DeQueue()
        {
            if (Count == 0)
                throw new Exception("Eleman Yok!");
            T sonuc = Peek();
            liste.RemoveFirst();
            return sonuc;
        }
    }
}
