using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGameEngine
{
    class Queue<T>
    {
        private LinkedList<T> items = new LinkedList<T>();

        public void Enqueue(T item) => items.AddToHead(item);
    
        public T Dequeue()
        {
            T head = items.Head;
            items.RemoveHead();

            return head;
        }

        public T Peek() => items.Head;

        public bool IsEmpty => items.Count == 0;
    }
}
