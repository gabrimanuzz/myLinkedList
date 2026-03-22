using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myList
{
    internal interface IList<T>
    {
        public void Add(T item);
        public void InsertAt(int index, T item);
        public bool Contains(T item);
        public void Clear();
        public T ElementAt(int index);
        public void RemoveAt(int index);
        public int Remove(T item);
        public int Find(T item);
    }
}
