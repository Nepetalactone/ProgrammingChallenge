using System;
using System.Collections.Generic;

namespace _00NameGenerator
{
    class ProbabilityList<T>
    {
        private readonly List<T> _list;

        public ProbabilityList()
        {
            _list = new List<T>();
        }

        public void Add(T item, Double probability)
        {
            for (int i = 0; i < probability * 10; i++)
            {
                _list.Add(item);
            }
        }

        public void Remove(T item)
        {
            _list.RemoveAll(obj => obj.Equals(item));
        }

        public T GetRandomItem()
        {
            Random rand = new Random();
            return _list[rand.Next(_list.Count)];
        }
    }
}
