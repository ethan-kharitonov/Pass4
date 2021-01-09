using System;
using System.Collections.Generic;

namespace CSGameEngine
{
    class LinkedList<T>
    {
        private Node<T> head;
        public T Head => head.Data;

        public int Count { get; set; } = 0;

        public void AddToTail(T data) => Insert(data, n => n.Next == null);

        public bool Insert(T data, Func<Node<T>, bool> prevQuery)
        {
            if (head == null)
            {
                head = new Node<T>(data);
                ++Count;
                return true;
            }

            Node<T> prev = QueryNode(prevQuery);

            if (prev == null)
            {
                return false;
            }

            Node<T> node = new Node<T>(data);

            node.Next = prev.Next;
            prev.Next = node;

            ++Count;

            return true;
        }

        public void AddToHead(T data)
        {
            Node<T> node = new Node<T>(data);

            node.Next = head;
            head = node;

            ++Count;
        }

        public bool Remove(Func<Node<T>, bool> query)
        {
            Node<T> prev = QueryNode(n => n.Next != null && query(n.Next));

            if (prev == null)
            {
                if (head != null && query(head))
                {
                    RemoveHead();
                    return true;
                }
                return false;
            }

            prev.Next = prev.Next.Next;
            --Count;
            return true;
        }

        public bool RemoveHead()
        {
            if (head == null)
            {
                return false;
            }

            head = head.Next;
            --Count;
            return true;
        }

        private Node<T> QueryNode(Func<Node<T>, bool> query)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (query(current))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        public T Query(Func<T, bool> query)
        {
            Node<T> res = QueryNode(n => query(n.Data));

            if (res != null)
            {
                return res.Data;
            }

            return default;
        }

        public IEnumerable<T> Yieldemployees()
        {
            Node<T> current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }


    }
}