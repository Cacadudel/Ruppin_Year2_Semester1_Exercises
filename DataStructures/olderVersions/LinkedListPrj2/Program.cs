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
        // 11. בדיקה האם ערך מסויים קיים ברשימה
        public static bool ValueExists<T>(Node<T> head, T value)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.GetValue().Equals(value))
                    return true;
                current = current.GetNext();
            }
            return false;
        }

        // 12. בדיקת רשימה מחזורית
        public static bool IsCircular<T>(Node<T> head)
        {
            if (head == null || !head.HasNext())
                return false;

            Node<T> slow = head;
            Node<T> fast = head;

            while (fast != null && fast.HasNext())
            {
                slow = slow.GetNext();
                fast = fast.GetNext().GetNext();

                if (slow == fast)
                    return true;
            }

            return false;
        }

        // 13. הדפסת הרשימה- לא נתקע אם מחזורי
        public static void PrintList<T>(Node<T> head)
        {
            if (head == null)
            {
                Console.WriteLine("null");
                return;
            }

            bool isCircular = IsCircular(head);

            Node<T> current = head;
            Node<T> firstNode = head;
            bool completedCycle = false;

            while (current != null && !completedCycle)
            {
                Console.Write(current.GetValue() + " -> ");

                current = current.GetNext();

                if (isCircular && current == firstNode)
                {
                    completedCycle = true;
                }
            }

            if (isCircular)
            {
                Console.WriteLine("... (Circular back to " + firstNode.GetValue() + ")");
            }
            else
            {
                Console.WriteLine("null");
            }
        }

        // 14. הסרת כפילויות מרשימה
        public static void RemoveDuplicates<T>(Node<T> head)
        {
            if (head == null || !head.HasNext())
                return;

            Node<T> current = head;

            while (current != null && current.HasNext())
            {
                Node<T> runner = current;

                while (runner.HasNext())
                {
                    if (runner.GetNext().GetValue().Equals(current.GetValue()))
                    {
                        runner.SetNext(runner.GetNext().GetNext());
                    }
                    else
                    {
                        runner = runner.GetNext();
                    }
                }

                current = current.GetNext();
            }
        }

        // 15. העתקת רשימה ללא כפילויות
        public static Node<T> CreateListWithoutDuplicates<T>(Node<T> head)
        {
            if (head == null)
                return null;

            Node<T> newList = new Node<T>(head.GetValue());
            Node<T> current = head.GetNext();

            while (current != null && current != head)
            {
                if (!ValueExists(newList, current.GetValue()))
                {
                    AddLast(newList, current.GetValue());
                }
                current = current.GetNext();
            }

            return newList;
        }

        // 16. יצירת עותר בכתובת זיכרון שונה
        public static Node<T> CopyList<T>(Node<T> head)
        {
            if (head == null)
                return null;

            Node<T> newList = new Node<T>(head.GetValue());
            Node<T> current = head.GetNext();
            Node<T> currentCopy = newList;

            while (current != null && current != head)
            {
                Node<T> newNode = new Node<T>(current.GetValue());
                currentCopy.SetNext(newNode);
                currentCopy = newNode;
                current = current.GetNext();
            }

            if (IsCircular(head))
            {
                currentCopy.SetNext(newList);
            }

            return newList;
        }

        // 17. שינוי כיוון הרשימה בגגכג
        public static Node<T> ReverseList<T>(Node<T> head)
        {
            if (head == null || !head.HasNext())
                return head;

            bool isCircular = IsCircular(head);
            Node<T> lastNode = null;

            if (isCircular)
            {
                lastNode = head;
                while (lastNode.GetNext() != head)
                {
                    lastNode = lastNode.GetNext();
                }
                lastNode.SetNext(null);
            }

            Node<T> prev = null;
            Node<T> current = head;
            Node<T> next = null;

            while (current != null)
            {
                next = current.GetNext();
                current.SetNext(prev);
                prev = current;
                current = next;
            }

            if (isCircular)
            {
                head.SetNext(prev);
            }

            return prev;
        }

        // 18. מיון מהקטן ביותר לגדול ביותר
        public static Node<T> SortList<T>(Node<T> head) where T : IComparable<T>
        {
            if (head == null || !head.HasNext())
                return head;

            bool swapped;
            Node<T> current;
            Node<T> last = null;

            do
            {
                swapped = false;
                current = head;

                while (current.HasNext() && current.GetNext() != last)
                {
                    if (current.GetValue().CompareTo(current.GetNext().GetValue()) > 0)
                    {
                        T temp = current.GetValue();
                        current.SetValue(current.GetNext().GetValue());
                        current.GetNext().SetValue(temp);
                        swapped = true;
                    }
                    current = current.GetNext();
                }
                last = current;
            }
            while (swapped);

            return head;
        }
        //השוואת רשימות
        public static bool AreListsEqual<T>(Node<T> list1, Node<T> list2) where T : IEquatable<T>
        {
            if (IsCircular(list1) != IsCircular(list2))
                return false;

            Node<T> current1 = list1;
            Node<T> current2 = list2;

            if (IsCircular(list1))
            {
                Node<T> startNode1 = list1;
                bool firstIteration = true;

                while (firstIteration || current1 != startNode1)
                {
                    firstIteration = false;

                    if (current2 == null || !current1.GetValue().Equals(current2.GetValue()))
                        return false;

                    current1 = current1.GetNext();
                    current2 = current2.GetNext();
                }

                return current2 == list2;
            }
            else
            {
                while (current1 != null && current2 != null)
                {
                    if (!current1.GetValue().Equals(current2.GetValue()))
                        return false;

                    current1 = current1.GetNext();
                    current2 = current2.GetNext();
                }

                return current1 == null && current2 == null;
            }
        }

        // 20. מיזוג מלא
        public static Node<T> MergeLists<T>(Node<T> list1, Node<T> list2)
        {
            if (list1 == null)
                return CopyList(list2);
            if (list2 == null)
                return CopyList(list1);

            Node<T> result = CopyList(list1);

            // שילוב חלקי
            Node<T> current = result;
            while (current.HasNext())
            {
                current = current.GetNext();
            }

            Node<T> list2Copy = CopyList(list2);
            current.SetNext(list2Copy);

            return result;
        }

        // 21. מיזוג ללא כפילויות
        public static Node<T> MergeListsNoDuplicates<T>(Node<T> list1, Node<T> list2) where T : IEquatable<T>
        {
            if (list1 == null)
                return CopyList(list2);
            if (list2 == null)
                return CopyList(list1);

            Node<T> result = CopyList(list1);
            Node<T> current = list2;
            Node<T> startNode = list2;
            bool firstIteration = true;

            while (current != null && (firstIteration || current != startNode))
            {
                firstIteration = false;

                if (!ValueExists(result, current.GetValue()))
                    AddLast(result, current.GetValue());

                current = current.GetNext();

                if (current == startNode)
                    break;
            }

            return result;
        }

        // 22. חיתוך
        public static Node<T> IntersectLists<T>(Node<T> list1, Node<T> list2) where T : IEquatable<T>
        {
            if (list1 == null || list2 == null)
                return null;

            Node<T> result = null;
            Node<T> current = list1;
            Node<T> startNode = list1;
            bool firstIteration = true;

            while (current != null && (firstIteration || current != startNode))
            {
                firstIteration = false;

                if (ValueExists(list2, current.GetValue()))
                {
                    if (result == null)
                        result = new Node<T>(current.GetValue());
                    else if (!ValueExists(result, current.GetValue()))
                        AddLast(result, current.GetValue());
                }

                current = current.GetNext();

                if (current == startNode)
                    break;
            }

            return result;
        }
    }
}
