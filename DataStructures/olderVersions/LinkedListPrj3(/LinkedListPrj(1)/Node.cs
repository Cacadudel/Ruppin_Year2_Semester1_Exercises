using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPrj
{
    internal class Node<T> :IComparable
    {
        private T value;
        private Node<T> next;

        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }

        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }

        public T GetValue()
        {
            return value;
        }

        public Node<T> GetNext()

        {
            return next;
        }

        public bool HasNext()
        {
            return next != null;
        }

        public void SetValue(T value)
        {
            this.value = value;
        }

        public void SetNext(Node<T> next)
        {
            this.next = next;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Node<T> other = obj as Node<T>;
            if (other == null)
                throw new ArgumentException("Object is not a Node<T>");

            return ((IComparable)this.value).CompareTo(other.value);
        }

        public override string ToString()
        {
            if (next == null)
            {
                return value + " --> null";
            }

            return value + " --> " + next;
        }
    }
}
