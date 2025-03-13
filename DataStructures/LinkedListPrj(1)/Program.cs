using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPrj
{
    internal class Program
    {
        static Node<int> list1;
        static Node<int> list2;
        //static Node<int> activeList;

        static Node<Worker> workerList1;
        static Node<Worker> workerList2;
       


        static void Main(string[] args)
        {
            InitializeLists();
            #region menu
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("===== Linked List Operations Menu =====");
                //Console.WriteLine("0. Switch Active List (Current: List" + (activeList == list1 ? "1" : "2") + ")");
                Console.WriteLine("1. Get List Length");
                Console.WriteLine("2. Add Value at Beginning");
                Console.WriteLine("3. Add Value at End");
                Console.WriteLine("4. Add Value After Position");
                Console.WriteLine("5. Delete First Node");
                Console.WriteLine("6. Delete Last Node");
                Console.WriteLine("7. Delete Node After Position");
                Console.WriteLine("8. Get First Value");
                Console.WriteLine("9. Get Last Value");
                Console.WriteLine("10. Get Value by Position");
                Console.WriteLine("11. Search for Value");
                Console.WriteLine("12. Check if List is Circular");
                Console.WriteLine("13. Display List");
                Console.WriteLine("14. Remove Duplicate Values");
                Console.WriteLine("15. Create List Without Duplicates");
                Console.WriteLine("16. Copy List (Show Memory Addresses)");
                Console.WriteLine("17. Reverse List");
                Console.WriteLine("18. Sort List");
                Console.WriteLine("19. Compare Lists for Equality");
                Console.WriteLine("20. Merge Two Lists");
                Console.WriteLine("21. Merge Lists Without Duplicates");
                Console.WriteLine("22. Get Common Values Between Lists");
                Console.WriteLine("23. Use previous functions on Worker Lists");
                Console.WriteLine("24. Calculate Student Grade Averages");
                Console.WriteLine("25. Find Top Student from Each Class");
                Console.WriteLine("26. Find Students with Most Failed Courses");
                Console.WriteLine("27. Toggle List Circularity");
                Console.WriteLine("28. Exit");
                Console.Write("Choose an option: ");
                #endregion
                string choice = Console.ReadLine();
                Console.Clear();
                #region Switch case
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("List1 Length: " + GetLength(list1));
                        break;

                    case "2":
                        Console.Write("Enter value to add at start: ");
                        string inputValue = Console.ReadLine();
                        int valueToAdd = int.Parse(inputValue);
                        list1 = AddFirst(list1, valueToAdd);
                        Console.WriteLine("List1 after AddFirst: ");
                        PrintList(list1);
                        break;

                    case "3":
                        Console.Write("Enter value to add at end: ");
                        inputValue = Console.ReadLine();
                        valueToAdd = int.Parse(inputValue);
                        if (list1 == null)
                        {
                            list1 = new Node<int>(valueToAdd);
                        }
                        else
                        {
                            AddLast(list1, valueToAdd);
                        }
                        Console.WriteLine("List1 after AddLast: ");
                        PrintList(list1);
                        break;

                    case "4":
                        Console.Write("Enter position to add after (starting from 0): ");
                        string positionInput = Console.ReadLine();
                        int position = int.Parse(positionInput);

                        Node<int> currentNode = list1;
                        int currentPos = 0;

                        while (currentNode != null && currentPos < position)
                        {
                            currentNode = currentNode.GetNext();
                            currentPos++;
                        }

                        if (currentNode != null)
                        {
                            Console.Write("Enter value to add: ");
                            inputValue = Console.ReadLine();
                            valueToAdd = int.Parse(inputValue);

                            AddAfter(currentNode, valueToAdd);
                            Console.WriteLine("List1 after AddAfter: ");
                            PrintList(list1);
                        }
                        else
                        {
                            Console.WriteLine("Position out of range");
                        }
                        break;

                    case "5":
                        list1 = DeleteFirst(list1);
                        Console.WriteLine("List1 after DeleteFirst: ");
                        PrintList(list1);
                        break;

                    case "6":
                        DeleteLast(list1);
                        Console.WriteLine("List1 after DeleteLast: ");
                        PrintList(list1);
                        break;

                    case "7":
                        DeleteAfter(list1.GetNext());
                        Console.WriteLine("List1 after DeleteAfter: ");
                        PrintList(list1);
                        break;

                    case "8":
                        Console.WriteLine("First Value in List1: " + GetFirstValue(list1));
                        break;

                    case "9":
                        Console.WriteLine("Last Value in List1: " + GetLastValue(list1));
                        break;

                    case "10":
                        Console.Write("Enter position to get value from: ");
                        positionInput = Console.ReadLine();
                        position = int.Parse(positionInput);
                        try
                        {
                            int value = GetValueAtIndex(list1, position);
                            Console.WriteLine($"Value at position {position}: {value}");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Position out of range");
                        }
                        break;

                    case "11":
                        Console.Write("Enter value to check for: ");
                        inputValue = Console.ReadLine();
                        valueToAdd = int.Parse(inputValue);
                        Console.WriteLine($"Value {valueToAdd} exists in List1: " + ValueExists(list1, valueToAdd));
                        break;

                    case "12":
                        Console.WriteLine("List1 is Circular: " + IsCircular(list1));
                        break;

                    case "13":
                        Console.WriteLine("Printing List1:");
                        PrintList(list1);
                        break;

                    case "14":
                        RemoveDuplicates(list1);
                        Console.WriteLine("List1 after RemoveDuplicates: ");
                        PrintList(list1);
                        break;

                    case "15":
                        Node<int> noDuplicates = CreateListWithoutDuplicates(list1);
                        Console.WriteLine("List1 without duplicates: ");
                        PrintList(noDuplicates);
                        break;

                    case "16":
                        Console.WriteLine($"Original list memory address: {list1.GetHashCode()}");
                        Node<int> copiedList = CopyList(list1);
                        Console.WriteLine($"Copied list memory address: {copiedList.GetHashCode()}");
                        Console.WriteLine("Original List1: ");
                        PrintList(list1);
                        Console.WriteLine("Copied List1: ");
                        PrintList(copiedList);
                        break;

                    case "17":
                        list1 = ReverseList(list1);
                        Console.WriteLine("List1 after Reverse: ");
                        PrintList(list1);
                        break;

                    case "18":
                        list1 = SortList(list1);
                        Console.WriteLine("List1 after Sort: ");
                        PrintList(list1);
                        break;

                    case "19":
                        Console.WriteLine("List1 and List2 are equal: " + AreListsEqual(list1, list2));
                        break;

                    case "20":
                        Node<int> mergedList = MergeLists(list1, list2);
                        Console.WriteLine("Merged List: ");
                        PrintList(mergedList);
                        break;

                    case "21":
                        Node<int> mergedNoDup = MergeListsNoDuplicates(list1, list2);
                        Console.WriteLine("Merged List without duplicates: ");
                        PrintList(mergedNoDup);
                        break;

                    case "22":
                        Node<int> intersectedList = IntersectLists(list1, list2);
                        Console.WriteLine("Intersected List: ");
                        PrintList(intersectedList);
                        break;

                    case "23":
                        Console.WriteLine("Running all functions on worker lists...");
                        RunAllWorkerListOperations();
                        break;

                    case "24":
                        Console.WriteLine("Printing average grades of students: ");

                        Node<Course> courses1 = new Node<Course>(new Course("OOP", 80));
                        AddLast(courses1, new Course("React", 90));
                        AddLast(courses1, new Course("SQL", 85));

                        Node<Student> studentList = new Node<Student>(new Student("Avi", courses1));
                        AddLast(studentList, new Student("David", courses1));

                        PrintStudentGradesAverage(studentList);
                        break;

                    case "25":
                        Console.WriteLine("Top students from each class:");

                        // יצירת רשימת קורסים לכיתה 1
                        Node<Course> class1Courses = new Node<Course>(new Course("OOP", 80));
                        AddLast(class1Courses, new Course("React", 90));

                        // יצירת רשימת קורסים לכיתה 2
                        Node<Course> class2Courses = new Node<Course>(new Course("OOP", 60));
                        AddLast(class2Courses, new Course("SQL", 75));

                        // יצירת רשימת סטודנטים לכיתה 1
                        Node<Student> class1Students = new Node<Student>(new Student("Naor", class1Courses));
                        AddLast(class1Students, new Student("Shai", class2Courses));

                        // יצירת רשימת סטודנטים לכיתה 2
                        Node<Student> class2Students = new Node<Student>(new Student("David", class1Courses));
                        AddLast(class2Students, new Student("Avi", class2Courses));

                        // יצירת רשימה מקושרת של כיתות (כל כיתה היא רשימה של סטודנטים)
                        Node<Node<Student>> classList = new Node<Node<Student>>(class1Students);
                        AddLast(classList, class2Students);

                        // הפעלת הפונקציה עם הרשימה המקושרת החדשה
                        Node<Student> topStudents = GetTopStudents(classList);

                        // הדפסת הסטודנטים המצטיינים
                        PrintList(topStudents);
                        break;

                    case "26":
                        Console.WriteLine("Students with most fails:");

                        // יצירת רשימת קורסים עם ציונים נמוכים (כשלונות)
                        Node<Course> failCourses1 = new Node<Course>(new Course("OOP", 50));
                        AddLast(failCourses1, new Course("React", 55));

                        Node<Course> failCourses2 = new Node<Course>(new Course("SQL", 60));
                        AddLast(failCourses2, new Course("OOP", 40));

                        // יצירת סטודנטים שנכשלו בקורסים
                        Node<Student> failStudents1 = new Node<Student>(new Student("Or", failCourses1));
                        Node<Student> failStudents2 = new Node<Student>(new Student("Yoni", failCourses2));

                        // יצירת רשימה מקושרת של רשימות סטודנטים (כל כיתה היא רשימה של סטודנטים)
                        Node<Node<Student>> studentLists = new Node<Node<Student>>(failStudents1);
                        AddLast(studentLists, failStudents2);

                        // הפעלת הפונקציה עם הרשימה המקושרת
                        Node<Student> failedStudents = GetStudentsWithMostFails(studentLists);

                        // הדפסת הסטודנטים עם הכי הרבה כשלונות מכל כיתה
                        PrintList(failedStudents);
                        break;


                    case "27":
                        ToggleCircular(list1);
                        Console.WriteLine($"List1 circularity toggled. Is now circular: {IsCircular(list1)}");
                        PrintList(list1);
                        break;

                    case "28":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                #endregion

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Exiting the program. Goodbye!");
        }

        static void InitializeLists()
        {
            // רשימות מספרים שלמים
            list1 = new Node<int>(1);
            AddLast(list1, 2);
            AddLast(list1, 3);
            AddLast(list1, 4);
            AddLast(list1, 5);

            list2 = new Node<int>(5);
            AddLast(list2, 4);
            AddLast(list2, 3);
            AddLast(list2, 2);
            AddLast(list2, 1);

            //activeList = list1;

            // רשימות עובדים
            workerList1 = new Node<Worker>(new Worker("David", 5000));
            AddLast(workerList1, new Worker("Naor", 7000));
            AddLast(workerList1, new Worker("Shai", 6000));

            workerList2 = new Node<Worker>(new Worker("Ron", 4500));
            AddLast(workerList2, new Worker("Avi", 8000));

            
        }
        #region Naor starters
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

        // 3. הוספת ערך בסוף הרשימה - Modified to handle null list
        public static void AddLast<T>(Node<T> head, T value)
        {
            if (head == null)
                return;

            Node<T> newNode = new Node<T>(value);

            while (head.HasNext())
            {
                head = head.GetNext();
            }

            head.SetNext(newNode);
        }

        // 4. הוספת ערך באמצע הרשימה AddAfter - Modified to handle null prevNode
        public static void AddAfter<T>(Node<T> prevNode, T value)
        {
            if (prevNode == null)
                return;

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
            //------------------------------- בדיקה אם הרשימה ריקה
            if (head == null)
                throw new ArgumentException("List is null");

            //------------------------------- בדיקה אם האינדקס שלילי – זהו ערך לא חוקי
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Index cannot be negative.");

            int currentIndex = 0;

            //------------------------------- מעבר על הרשימה תוך חיפוש האינדקס המתאים
            while (head != null)
            {
                //------------------------------- אם האינדקס הנוכחי שווה לאינדקס המבוקש, נחזיר את הערך שנמצא שם
                if (currentIndex == index)
                {
                    return head.GetValue();
                }

                //------------------------------- התקדמות לצומת הבא
                currentIndex++;
                head = head.GetNext();
            }

            //------------------------------- אם יצאנו מהלולאה בלי להחזיר ערך, המשמעות היא שאין את הערך

            throw new ArgumentException($"No value found at index {index}. The list contains only {currentIndex}.");
        
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
        #endregion
        #region Shai middles
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

        // 17. שינוי כיוון הרשימה
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

        // 19. השוואת רשימות
        public static bool AreListsEqual<T>(Node<T> list1, Node<T> list2)
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
        public static Node<T> MergeListsNoDuplicates<T>(Node<T> list1, Node<T> list2)
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
        public static Node<T> IntersectLists<T>(Node<T> list1, Node<T> list2)
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

        // החלת מחזוריות לשם בדיקה
        public static void ToggleCircular<T>(Node<T> head)
        {
            if (head == null)
                return;

            bool isCurrentlyCircular = IsCircular(head);

            if (isCurrentlyCircular)
            {
                // Find the node that points back to head
                Node<T> current = head;
                while (current.GetNext() != head)
                {
                    current = current.GetNext();
                }

                // Break the circle
                current.SetNext(null);
            }
            else
            {
                // Make it circular by connecting last node to head
                Node<T> current = head;
                while (current.HasNext())
                {
                    current = current.GetNext();
                }

                current.SetNext(head);
            }
        }
        #endregion

        // 23. מריץ את כל הפונקציות הקודמות רק על רשימות של WORKER
        public static void RunAllWorkerListOperations()
        {
            Console.WriteLine("========== Running All Functions on Worker Lists ==========\n");

            // 1. החזרת אורך
            Console.WriteLine("1. Get List Length:");
            Console.WriteLine($"WorkerList1 Length: {GetLength(workerList1)}");
            Console.WriteLine($"WorkerList2 Length: {GetLength(workerList2)}");
            Console.WriteLine();

            // 2. הוספת ערך בהתחלה
            Console.WriteLine("2. Add Value at Beginning:");
            Worker newWorker = new Worker("AddedFirst", 9000);
            workerList1 = AddFirst(workerList1, newWorker);
            Console.WriteLine("WorkerList1 after AddFirst:");
            PrintList(workerList1);
            Console.WriteLine();

            // 3. הוספת ערך בסוף
            Console.WriteLine("3. Add Value at End:");
            AddLast(workerList1, new Worker("AddedLast", 4800));
            Console.WriteLine("WorkerList1 after AddLast:");
            PrintList(workerList1);
            Console.WriteLine();

            // 4. הוספת ערך אחרי מיקום
            Console.WriteLine("4. Add Value After Position:");
            AddAfter(workerList1.GetNext(), new Worker("AddedAfter", 5500));
            Console.WriteLine("WorkerList1 after AddAfter:");
            PrintList(workerList1);
            Console.WriteLine();

            // שמירת המצב הקיים שלרשימה 1
            Node<Worker> workerList1Copy = CopyList(workerList1);

            // 5. מחיקת ערך התחלתי
            Console.WriteLine("5. Delete First Node:");
            workerList1 = DeleteFirst(workerList1);
            Console.WriteLine("WorkerList1 after DeleteFirst:");
            PrintList(workerList1);
            Console.WriteLine();

            // 6. מחיקת הערך האחרון
            Console.WriteLine("6. Delete Last Node:");
            DeleteLast(workerList1);
            Console.WriteLine("WorkerList1 after DeleteLast:");
            PrintList(workerList1);
            Console.WriteLine();

            // 7. מחיקת ערך לפי מיקום
            Console.WriteLine("7. Delete After Position:");
            if (workerList1 != null && workerList1.HasNext())
            {
                DeleteAfter(workerList1);
                Console.WriteLine("WorkerList1 after DeleteAfter:");
                PrintList(workerList1);
            }
            else
            {
                Console.WriteLine("Cannot delete after: List is too short");
            }
            Console.WriteLine();

            // החזרת רשימה 1 לערך השמור
            workerList1 = workerList1Copy;

            // 8. החזרת ערך ראשון
            Console.WriteLine("8. Get First Value:");
            Console.WriteLine("First Worker in WorkerList1: " + GetFirstValue(workerList1));
            Console.WriteLine();

            // 9. החזרת ערך אחרון
            Console.WriteLine("9. Get Last Value:");
            Console.WriteLine("Last Worker in WorkerList1: " + GetLastValue(workerList1));
            Console.WriteLine();

            // 10. החזרת ערך לפי מיקום
            Console.WriteLine("10. Get Value at Index:");
            try
            {
                Console.WriteLine("Value at position 1 in WorkerList1: " + GetValueAtIndex(workerList1, 1));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.WriteLine();

            // 11. חיפוש ערך ברשימה
            Console.WriteLine("11. Value Exists Check:");
            Console.WriteLine("Worker 'Naor' exists in WorkerList1: " +
                ValueExists(workerList1, new Worker("Naor", 7000)));
            Console.WriteLine();

            // 12. בדיקת מעגליות
            Console.WriteLine("12. Check if List is Circular:");
            Console.WriteLine("WorkerList1 is circular: " + IsCircular(workerList1));
            Console.WriteLine();

            // 13. הצגת הרשימה
            Console.WriteLine("13. Display List:");
            Console.WriteLine("WorkerList1:");
            PrintList(workerList1);
            Console.WriteLine("WorkerList2:");
            PrintList(workerList2);
            Console.WriteLine();

            // 14. הסרת כפילויות
            Console.WriteLine("14. Remove Duplicates:");
            // הוספת ערך שכבר קיים ליצירת כפילות
            AddLast(workerList1, new Worker("Naor", 7000));
            Console.WriteLine("WorkerList1 with duplicate:");
            PrintList(workerList1);
            RemoveDuplicates(workerList1);
            Console.WriteLine("WorkerList1 after removing duplicates:");
            PrintList(workerList1);
            Console.WriteLine();

            // 15. יצירת העתק ללא כפילויות
            Console.WriteLine("15. Create List Without Duplicates:");
            // החזרת הכפילות
            AddLast(workerList1, new Worker("Naor", 7000));
            Console.WriteLine("WorkerList1 with duplicate:");
            PrintList(workerList1);
            Node<Worker> noDuplicatesList = CreateListWithoutDuplicates(workerList1);
            Console.WriteLine("New list without duplicates:");
            PrintList(noDuplicatesList);
            Console.WriteLine();

            // 16. העתקת רשימה
            Console.WriteLine("16. Copy List:");
            Node<Worker> copiedList = CopyList(workerList1);
            Console.WriteLine($"Original WorkerList1 memory address: {workerList1.GetHashCode()}");
            Console.WriteLine($"Copied list memory address: {copiedList.GetHashCode()}");
            Console.WriteLine("Original list:");
            PrintList(workerList1);
            Console.WriteLine("Copied list:");
            PrintList(copiedList);
            Console.WriteLine();

            // 17. שינוי כיוון הרשימה/ חברה יש לנו מהפך!
            Console.WriteLine("17. Reverse List:");
            Node<Worker> reversedList = ReverseList(CopyList(workerList1)); // Use a copy to not affect original
            Console.WriteLine("Original WorkerList1:");
            PrintList(workerList1);
            Console.WriteLine("Reversed list:");
            PrintList(reversedList);
            Console.WriteLine();

            // 18. מיון רשימה
            Console.WriteLine("18. Sort List:");
            Console.WriteLine("Note: Sorting skipped as Worker would need to implement IComparable");
            Console.WriteLine();

            // 19. בדיקת שוויון - לא יודע אני עייף ולא זוכר מילים...
            Console.WriteLine("19. Compare Lists for Equality:");
            Console.WriteLine("WorkerList1 equals WorkerList2: " + AreListsEqual(workerList1, workerList2));
            Console.WriteLine("WorkerList1 equals its copy: " + AreListsEqual(workerList1, copiedList));
            Console.WriteLine();

            // 20. מיזוג רשימות
            Console.WriteLine("20. Merge Lists:");
            Node<Worker> mergedList = MergeLists(workerList1, workerList2);
            Console.WriteLine("Merged list (WorkerList1 + WorkerList2):");
            PrintList(mergedList);
            Console.WriteLine();

            // 21. מיזוג ללא כפילויות
            Console.WriteLine("21. Merge Lists Without Duplicates:");
            Node<Worker> mergedNoDupList = MergeListsNoDuplicates(workerList1, workerList2);
            Console.WriteLine("Merged list without duplicates:");
            PrintList(mergedNoDupList);
            Console.WriteLine();

            // 22. חיתוך רשימות
            Console.WriteLine("22. Intersect Lists:");
            // הוספת ערך משותף
            AddLast(workerList2, new Worker("Naor", 7000));
            Console.WriteLine("Updated WorkerList2 with common worker:");
            PrintList(workerList2);
            Node<Worker> intersectedList = IntersectLists(workerList1, workerList2);
            Console.WriteLine("Common workers between WorkerList1 and WorkerList2:");
            PrintList(intersectedList);
            Console.WriteLine();

            Console.WriteLine("========== All Functions Completed ==========");
        }
        #region naor last funcs
        //24. הדפסת ממוצע הציונים של כל סטודנט ברשימה מקושרת
        // הפונקציה מחשבת ומדפיסה את ממוצע הציונים עבור כל סטודנט
        public static void PrintStudentGradesAverage(Node<Student> studentList)
        {
            while (studentList != null)
            {
                Student student = studentList.GetValue();
                Node<Course> courses = student.GetCourses();

                int sum = 0;
                int count = 0;

                while (courses != null)
                {
                    sum += (int)courses.GetValue().GetGrade();
                    count++;
                    courses = courses.GetNext();
                }

                double average = count > 0 ? (double)sum / count : 0;
                Console.WriteLine($"{student.GetName()}: Average Grade = {average}");

                studentList = studentList.GetNext();
            }
        }

        //25. החזרת רשימה של הסטודנטים המצטיינים מכל כיתה
        // הפונקציה מחזירה את הסטודנטים בעלי ממוצע הציונים הגבוה ביותר מכל כיתה

        public static Node<Student> GetTopStudents(Node<Node<Student>> classList)
        {
            if (classList == null)
                return null;

            Node<Student> topStudents = null;

            while (classList != null)
            {
                Node<Student> studentList = classList.GetValue();
                Student topStudent = null;
                double highestAverage = -1;

                while (studentList != null)
                {
                    Student student = studentList.GetValue();
                    Node<Course> courses = student.GetCourses();
                    int sum = 0;
                    int count = 0;

                    while (courses != null)
                    {
                        sum += (int)courses.GetValue().GetGrade();
                        count++;
                        courses = courses.GetNext();
                    }

                    double average = count > 0 ? (double)sum / count : 0;

                    if (average > highestAverage)
                    {
                        highestAverage = average;
                        topStudent = student;
                    }

                    studentList = studentList.GetNext();
                }

                if (topStudent != null)
                {
                    if (topStudents == null)
                    {
                        topStudents = new Node<Student>(topStudent);
                    }
                    else
                    {
                        AddLast(topStudents, topStudent);
                    }
                }

                classList = classList.GetNext();
            }

            return topStudents;
        }


        //26. החזרת סטודנטים עם הכי הרבה נכשלים מכל כיתה
        // הפונקציה מחזירה את הסטודנטים בעלי מספר הכשלונות הגבוה ביותר מכל רשימה בכיתה

        public static Node<Student> GetStudentsWithMostFails(Node<Node<Student>> studentLists)
        {
            Node<Student> failedStudents = null;

            while (studentLists != null)
            {
                Node<Student> studentList = studentLists.GetValue();
                Student topFailedStudent = null;
                int maxFails = -1;

                Node<Student> current = studentList;
                while (current != null)
                {
                    Student student = current.GetValue();
                    Node<Course> courses = student.GetCourses();

                    int fails = 0;

                    while (courses != null)
                    {
                        if (courses.GetValue().GetGrade() < 60)
                        {
                            fails++;
                        }
                        courses = courses.GetNext();
                    }

                    if (fails > maxFails)
                    {
                        maxFails = fails;
                        topFailedStudent = student;
                    }

                    current = current.GetNext();
                }

                if (topFailedStudent != null)
                {
                    if (failedStudents == null)
                    {
                        failedStudents = new Node<Student>(topFailedStudent);
                    }
                    else
                    {
                        AddLast(failedStudents, topFailedStudent);
                    }
                }

                studentLists = studentLists.GetNext();
            }

            return failedStudents;
        }

        #endregion
    }
}