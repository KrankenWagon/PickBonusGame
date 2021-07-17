using System.Collections.Generic;
using UnityEngine;

namespace Modular
{
    public abstract class ListVariable<T> : ScriptableObject
    {
        public List<T> ListValue = new List<T>();

        public void SetValue(int index, T value)
        {
            if (index < 0)
                return;

            if(index >= ListValue.Count)
                Resize(index + 1);

            ListValue[index] = value;
              
        }

        public T GetValue(int index)
        {
            // ensure index is valid
            if(index >= 0 && index < ListValue.Count)
                return ListValue[index];

            // if no valid index found
            return default;
        }

        public T GetRandomValue()
        {
            if (ListValue.Count > 0)
                return ListValue[Random.Range(0, ListValue.Count)];
            else
                return default;
        }

        public int GetRandomIndex()
        {
            if (ListValue.Count > 0)
                return Random.Range(0, ListValue.Count);
            else
                return default;
        }

        public T GetRandomValue(T excludeValue)
        {
            int index = Random.Range(0, ListValue.Count);

            if(ListValue[index].Equals(excludeValue))
            {
                if (index == ListValue.Count - 1)
                    index = 0;
                else
                    index++;
            }

            return ListValue[index];
        }

        public int Count()
        {
            return ListValue.Count;
        }

        public List<T> GetList()
        {
            return ListValue;
        }

        public void Clear()
        {
            ListValue.Clear();
        }

        public void ClearAndResize(int size)
        {
            Clear();

            for(int i = 0; i < size; i++)
                ListValue.Add(default);
        }

        public void Sort()
        {
            ListValue.Sort();
        }

        public void Resize(int newCount)
        {
            if (newCount <= 0)
            {
                ListValue.Clear();
            }
            else
            {
                while (ListValue.Count > newCount) ListValue.RemoveAt(ListValue.Count - 1);
                while (ListValue.Count < newCount) ListValue.Add(default);
            }
        }

        public bool Contains(T item)
        {
            return ListValue.Contains(item);
        }

        public void Add(T item)
        {
            ListValue.Add(item);
        }

        public void Remove(T item)
        {
            if(Contains(item))
                ListValue.Remove(item);
        }

        public void RemoveAt(int index)
        {
            if(index >= 0 && index < ListValue.Count)
                ListValue.RemoveAt(index);
        }

        public int IndexOf(T item)
        {
            return ListValue.IndexOf(item);
        }
    }
}