using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPrj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // יצירת רשימה מקושרת לדוגמה
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            AddLast(list, 3);
            AddLast(list, 4);
            AddLast(list, 5);

            Console.WriteLine("Initial List: " + list);

            // 1. החזרת אורך הרשימה
            int length = GetLength(list);
            Console.WriteLine("List Length: " + length);

            // 2. הוספת ערך בתחילת הרשימה
            list = AddFirst(list, 0);
            Console.WriteLine("After AddFirst: " + list);

            // 3. הוספת ערך בסוף הרשימה
            AddLast(list, 6);
            Console.WriteLine("After AddLast: " + list);

            // 4. הוספת ערך באמצע הרשימה AddAfter
            AddAfter(list.GetNext(), 1);
            Console.WriteLine("After AddAfter: " + list);

            // 5. מחיקת ערך בתחילת הרשימה
            list = DeleteFirst(list);
            Console.WriteLine("After DeleteFirst: " + list);

            // 6. מחיקת ערך בסוף הרשימה
            DeleteLast(list);
            Console.WriteLine("After DeleteLast: " + list);

            // 7. מחיקת ערך באמצע הרשימה DeleteAfter
            DeleteAfter(list.GetNext());
            Console.WriteLine("After DeleteAfter: " + list);

            // 8. החזרת הערך בתחילת הרשימה
            int firstValue = GetFirstValue(list);
            Console.WriteLine("First Value: " + firstValue);

            // 9. החזרת הערך בסוף הרשימה
            int lastValue = GetLastValue(list);
            Console.WriteLine("Last Value: " + lastValue);

            // 10. החזרת הערך לפי אינדקס שנשלח
            int valueAtIndex = GetValueAtIndex(list, 2);
            Console.WriteLine("Value at Index 2: " + valueAtIndex);
        }

        // 1. החזרת אורך הרשימה
        public static int GetLength<T>(Node<T> head)
        {
            int length = 0;
            while (head != null)
            {
                length++;
                head = head.GetNext();
            }
            return length;
        }

        // 2. הוספת ערך בתחילת הרשימה
        public static Node<T> AddFirst<T>(Node<T> head, T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.SetNext(head);
            return newNode;
        }

        // 3. הוספת ערך בסוף הרשימה
        public static void AddLast<T>(Node<T> head, T value)
        {
            Node<T> newNode = new Node<T>(value);

            while (head.HasNext())
            {
                head = head.GetNext();
            }

            head.SetNext(newNode);
        }

        // 4. הוספת ערך באמצע הרשימה AddAfter
        public static void AddAfter<T>(Node<T> prevNode, T value)
        {
            if (prevNode == null)
                throw new ArgumentException("Previous node is null");

            Node<T> newNode = new Node<T>(value);
            newNode.SetNext(prevNode.GetNext());
            prevNode.SetNext(newNode);
        }

        // 5. מחיקת ערך בתחילת הרשימה
        public static Node<T> DeleteFirst<T>(Node<T> head)
        {
            if (head == null)
                return null;

            Node<T> temp = head.GetNext();
            head.SetNext(null);
            return temp;
        }

        // 6. מחיקת ערך בסוף הרשימה
        public static void DeleteLast<T>(Node<T> head)
        {
            if (head == null || !head.HasNext())
                return;

            Node<T> temp = head;
            while (temp.GetNext().HasNext())
            {
                temp = temp.GetNext();
            }

            temp.SetNext(null);
        }

        // 7. מחיקת ערך באמצע הרשימה DeleteAfter
        public static void DeleteAfter<T>(Node<T> prevNode)
        {
            if (prevNode == null || !prevNode.HasNext())
                return;

            Node<T> temp = prevNode.GetNext();
            prevNode.SetNext(temp.GetNext());
            temp.SetNext(null);
        }

        // 8. החזרת הערך בתחילת הרשימה
        public static T GetFirstValue<T>(Node<T> head)
        {
            if (head == null)
                throw new ArgumentException("List is null");

            return head.GetValue();
        }

        // 9. החזרת הערך בסוף הרשימה
        public static T GetLastValue<T>(Node<T> head)
        {
            if (head == null)
                throw new ArgumentException("List is null");

            while (head.HasNext())
            {
                head = head.GetNext();
            }

            return head.GetValue();
        }

        // 10. החזרת הערך לפי אינדקס שנשלח
        public static T GetValueAtIndex<T>(Node<T> head, int index)
        {
            if (head == null)
                throw new ArgumentException("List is null");

            int currentIndex = 0;
            while (head != null)
            {
                if (currentIndex == index)
                {
                    return head.GetValue();
                }
                currentIndex++;
                head = head.GetNext();
            }

            throw new IndexOutOfRangeException("Index out of range");
        }
    }
}
