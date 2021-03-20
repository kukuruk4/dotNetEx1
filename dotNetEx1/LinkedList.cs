using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace dotNetEx1
{
    public class Node<T>
    {
        public Node<T> next = null;
        public T data;

        public Node(T Data)
        {
            data = Data;
        }
    }
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head = null;
        private Node<T> tail = null;
        private int count;
        public int Count
        {
            get { return count; }
        }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (head == null)
                head = node;
            else
                tail.next = node;
            tail = node;
            ++count;
        }

        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.next = head;
            head = node;
            if (count == 0)
            {
                tail = node;
            }
            ++count;
        }

        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.next = current.next;
                        if (current.next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.next;

                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.next;
            }
            return false;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.data.Equals(data))
                    return true;
                current = current.next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void reverse()
        {
            Node<T> previous = null,
                    current = head,
                    nextNode = head.next;
            while (nextNode != null)
            {
                current.next = previous;
                previous = current;
                current = nextNode;
                nextNode = current.next;
            }

            current.next = previous;
            tail = head;
            head = current;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }
    }
}
