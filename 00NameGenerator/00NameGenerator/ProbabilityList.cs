using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _00NameGenerator
{
    class ProbabilityList<T>
    {
        private readonly List<T> _list;
        private readonly Random _rng;

        public ProbabilityList()
        {
            _rng = new Random();
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
            return _list[_rng.Next(_list.Count)];
        }
    }
}
