using System;
using System.Collections;
using System.Collections.Generic;
using Veri_Yapilari_CS.Liste;

namespace Veri_Yapilari_CS.Sozluk
{
    public class Sozluk<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>
    {
        Liste<TKey> keys;
        Liste<TValue> values;
        public int Count => keys.Count;
        public bool IsReadOnly => false;
        public TKey[] Keys
        {
            get
            {
                TKey[] sonuc = new TKey[keys.Count];
                for (int i = 0; i < Count; i++)
                    sonuc[i] = keys[i];
                return sonuc;
            }
        }
        public TValue[] Values
        {
            get
            {
                TValue[] sonuc = new TValue[values.Count];
                for (int i = 0; i < Count; i++)
                    sonuc[i] = values[i];
                return sonuc;
            }
        }
        public TValue this[TKey key]
        {
            get => values[keys.IndexOf(key)];
            set { values[keys.IndexOf(key)] = value; }
        }
        public Sozluk()
        {
            keys = new Liste<TKey>();
            values = new Liste<TValue>();
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }
        public void Add(TKey key, TValue value)
        {
            if (keys.Contains(key))
                throw new ArgumentException("key değeri benzersiz olmalıdır");
            keys.Add(key); 
            values.Add(value);
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }
        public bool Remove(TKey key)
        {
            int index = keys.IndexOf(key);
            if (index == -1) return false;

            keys.RemoveAt(index);
            values.RemoveAt(index);

            return true;
        }

        public void Clear()
        {
            keys.Clear();
            values.Clear();
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            return keys.Contains(key);
        }
        public bool ContainsValue(TValue value)
        {
            return values.Contains(value);
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < keys.Count; i++)
                yield return KeyValuePair.Create(keys[i], values[i]);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
