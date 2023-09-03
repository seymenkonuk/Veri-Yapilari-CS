using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Veri_Yapilari_CS.Liste
{
    public class Liste<T> : ICollection<T>
    {
        T[] dizi;
        public int Count { get; private set; }
        public int Capasity => dizi.Length;
        public bool IsReadOnly => false;
        public T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new ArgumentOutOfRangeException("index");
                return dizi[index];
            }
            set
            {
                if (index >= Count)
                    throw new ArgumentOutOfRangeException("index");
                dizi[index] = value; 
            }
        }

        #region Yapılandırıcı Metotlar
        public Liste()
        {
            dizi = new T[2];
            Count = 0;
        }
        public Liste(int kapasite)
        {
            int i = 1;
            for (i = 1; i < kapasite; i *= 2);
            dizi = new T[i];
            Count = 0;
        }
        public Liste(params T[] values) : this(values.Length)
        {
            foreach (var item in values)
                Add(item);
        }
        public Liste(IEnumerable<T> collection) : this(collection.ToArray().Length)
        {
            foreach (var item in collection)
                Add(item);
        }
        #endregion

        public void Add(T item)
        {
            // Kapasiteyi Arttırmak Gerekiyorsa Arttır
            if (Count == Capasity)
            {
                T[] yeniDizi = new T[Capasity * 2];
                for (int i = 0; i < Count; i++)
                    yeniDizi[i] = dizi[i];
                dizi = yeniDizi;
            }
            // Elemanı Ekle
            dizi[Count++] = item;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Add(item);
        }
        public bool Remove(T item)
        {
            if (Count == 0) return false;

            return RemoveAt(IndexOf(item));
        }
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Count) return false;
            // İndexten sonrakileri 1 sola kaydır
            for (int i = index + 1; i < Count; i++)
                dizi[i - 1] = dizi[i];
            Count--;
            // Kapasitenin güncellenmesi gerekiyor mu
            if (Capasity / 4 == Count && Capasity > 2)
            {
                T[] yeniDizi = new T[Capasity / 2];
                for (int i = 0; i < Count; i++)
                    yeniDizi[i] = dizi[i];
                dizi = yeniDizi;
            }
            return true;
        }
        public bool RemoveLast()
        {
            return RemoveAt(Count-1);
        }

        public void Clear()
        {
            dizi = new T[2];
            Count = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
                if (dizi[i].Equals(item))
                    return i;
            return -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return dizi[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
