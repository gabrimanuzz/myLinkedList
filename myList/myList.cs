using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myList
{
    public class myList<T> : IList<T>, IEnumerable<T>
    {
        private Node<T>? _head;
        private Node<T>? _tail;
        public int Count { get; private set; }

        public myList()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public void Add(T value)
        {
            var newNode = new Node<T>(value);

            if (_head == null)
                _head = newNode;
            else
                _tail!.Next = newNode;

            _tail = newNode;
            Count++;
        }

        public void InsertAt(int index, T value)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                var newNode = new Node<T>(value);
                newNode.Next = _head;
                _head = newNode;
                if (Count == 0)
                    _tail = newNode;
                Count++;
                return;
            }

            if (index == Count)
            {
                Add(value);
                return;
            }

            Node<T>? current = _head;
            for (int i = 0; i < index - 1; i++)
                current = current!.Next;

            var node = new Node<T>(value);
            node.Next = current!.Next;
            current.Next = node;
            Count++;

        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node<T>? current = _head;
            for (int i = 0; i < index; i++)
                current = current!.Next;

            return current!.Value;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public bool Contains(T value)
        {
            Node<T>? current = _head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                    return true;
                current = current.Next;
            }
            return false;
        }

        // foreach implemented
        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                _head = _head!.Next;
                if (_head == null)
                    _tail = null;
                Count--;
                return;
            }

            Node<T>? current = _head;
            for (int i = 0; i < index - 1; i++)
                current = current!.Next;

            var toRemove = current!.Next!;
            current.Next = toRemove.Next;
            if (toRemove.Next == null)
                _tail = current;
            Count--;
        }

        public int Remove(T item)
        {
            int result = Find(item);

            if (result == -1)
                return -1;
            
            RemoveAt(result);
            return 0;

        }

        public int Find(T item)
        {
            Node<T>? current = _head;
            int i = 0;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, item))
                    return i;
                current = current.Next;
                i++;
            }
            return -1;
        }
    }
}
