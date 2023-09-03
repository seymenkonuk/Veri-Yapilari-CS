using System;
using System.Collections;
using System.Collections.Generic;
using Veri_Yapilari_CS.Kuyruk;
using Veri_Yapilari_CS.Sozluk;

namespace Veri_Yapilari_CS.AyrikSet
{
    public class AyrikSet<T> : IEnumerable<T>
    {
        Sozluk<T, AyrikSetNode<T>> setler = new Sozluk<T, AyrikSetNode<T>>();
        public int Count { get =>  setler.Count; }

        public AyrikSet()
        {

        }
        public AyrikSet(params T[] collection)
        {
            foreach (var item in collection)
                MakeSet(item);
        }
        public AyrikSet(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                MakeSet(item);
        }

        public void MakeSet(T value)
        {
            if (setler.ContainsKey(value))
                throw new Exception("Mevcut düğüm eklenemez.");
            var newset = new AyrikSetNode<T>(value);
            newset.Parent = newset;
            setler.Add(value, newset);
        }
        public T FindSet(T value, bool PathCompression = false)
        {
            if (PathCompression)
                return FindSetWithPathCompression(value);
            return FindSetNoPathCompression(value);
        }
        private T FindSetNoPathCompression(T value)
        {
            var node = setler[value];
            var parent = node.Parent;

            while (node != parent)
            {
                node = parent;
                parent = node.Parent;
            }
            return node.Value;
        }

        private T FindSetWithPathCompression(T value)
        {
            Kuyruk<AyrikSetNode<T>> nodes = new Kuyruk<AyrikSetNode<T>>();
            var node = setler[value];
            var parent = node.Parent;

            while (node != parent)
            {
                nodes.EnQueue(node);
                node = parent;
                parent = node.Parent;
            }

            while (nodes.Count > 0)
                nodes.DeQueue().Parent = node;

            return node.Value;
        }

        public void Union(T value1, T value2)
        {
            var node1 = FindSet(value1);
            var node2 = FindSet(value2);

            setler[node1].Parent = setler[node2];
        }

        public IEnumerator<T> GetEnumerator() {
            foreach (var item in setler.Keys)
                yield return item;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
