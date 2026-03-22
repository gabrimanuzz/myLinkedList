using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myList
{
    internal class Node<T>
    {
        public T Value;
        public Node<T>? Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }
}
