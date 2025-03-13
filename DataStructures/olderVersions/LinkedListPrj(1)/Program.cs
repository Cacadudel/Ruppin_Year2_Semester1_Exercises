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
           
                bool exit = false;

                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("===== Main Menu =====");
                    for (int i = 1; i <= 26; i++)
                    {
                        Console.WriteLine($"{i}. Function {i}");
                    }
                    Console.WriteLine("27. Exit");
                    Console.Write("Choose an option: ");

                    string choice = Console.ReadLine();
                    Console.Clear();

                    switch (choice)
                    {
                        case "1": TestGetLength(); break;
                        case "2": TestAddFirst(); break;
                        case "3": TestAddLast(); break;
                        case "4": TestAddAfter(); break;
                        case "5": TestDeleteFirst(); break;
                        case "6": TestDeleteLast(); break;
                        case "7": TestDeleteAfter(); break;
                        case "8": TestGetFirstValue(); break;
                        case "9": TestGetLastValue(); break;
                        case "10": TestGetValueAtIndex(); break;
                        case "11": TestValueExists(); break;
                        case "12": TestIsCircular(); break;
                        case "13": TestPrintList(); break;
                        case "14": TestRemoveDuplicates(); break;
                        case "15": TestCreateListWithoutDuplicates(); break;
                        case "16": TestCopyList(); break;
                        case "17": TestReverseList(); break;
                        case "18": TestSortList(); break;
                        case "19": TestAreListsEqual(); break;
                        case "20": TestMergeLists(); break;
                        case "21": TestMergeListsNoDuplicates(); break;
                        case "22": TestIntersectLists(); break;
                        case "23": TestFunctionsOnIntAndWorkerLists(); break;
                        case "24": TestPrintStudentGradesAverage(); break;
                        case "25": TestGetTopStudents(); break;
                        case "26": TestGetStudentsWithMostFails(); break;
                        case "27": exit = true; break;
                        default: Console.WriteLine("Invalid option. Please try again."); break;
                    }

                    if (!exit)
                    {
                        Console.WriteLine("\nPress any key to return to the main menu...");
                        Console.ReadKey();
                    }
                }

                Console.WriteLine("Exiting the program. Goodbye!");
            


        }




        // 1. בדיקת פונקציה שמחזירה את אורך הרשימה
        public static void TestGetLength()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            AddLast(list, 3);
            Console.WriteLine("List: " + list);
            Console.WriteLine("Length: " + GetLength(list));
        }

        // 2. בדיקת הוספת ערך בתחילת הרשימה
        public static void TestAddFirst()
        {
            Node<int> list = new Node<int>(2);
            list = AddFirst(list, 1);
            Console.WriteLine("List after AddFirst: " + list);
        }

        // 3. בדיקת הוספת ערך בסוף הרשימה
        public static void TestAddLast()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            AddLast(list, 3);
            Console.WriteLine("List after AddLast: " + list);
        }

        // 4. בדיקת הוספת ערך אחרי צומת ספציפי
        public static void TestAddAfter()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 3);
            AddAfter(list, 2);
            Console.WriteLine("List after AddAfter: " + list);
        }

        // 5. בדיקת מחיקת ערך בתחילת הרשימה
        public static void TestDeleteFirst()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            list = DeleteFirst(list);
            Console.WriteLine("List after DeleteFirst: " + list);
        }

        // 6. בדיקת מחיקת ערך בסוף הרשימה
        public static void TestDeleteLast()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            AddLast(list, 3);
            DeleteLast(list);
            Console.WriteLine("List after DeleteLast: " + list);
        }

        // 7. בדיקת מחיקת ערך אחרי צומת ספציפי
        public static void TestDeleteAfter()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            AddLast(list, 3);
            DeleteAfter(list);
            Console.WriteLine("List after DeleteAfter: " + list);
        }

        // 8. בדיקת החזרת הערך הראשון ברשימה
        public static void TestGetFirstValue()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            Console.WriteLine("First value: " + GetFirstValue(list));
        }

        // 9. בדיקת החזרת הערך האחרון ברשימה
        public static void TestGetLastValue()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            AddLast(list, 3);
            Console.WriteLine("Last value: " + GetLastValue(list));
        }

        // 10. בדיקת החזרת ערך לפי אינדקס נתון
        public static void TestGetValueAtIndex()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            AddLast(list, 3);
            Console.WriteLine("Value at index 1: " + GetValueAtIndex(list, 1));
        }

        // 11. בדיקת האם ערך מסוים קיים ברשימה
        public static void TestValueExists()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            Console.WriteLine("Value 2 exists: " + ValueExists(list, 2));
        }

        // 12. בדיקת האם הרשימה מעגלית
        public static void TestIsCircular()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            Console.WriteLine("Is circular: " + IsCircular(list));
        }

        // 13. בדיקת הדפסת הרשימה
        public static void TestPrintList()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            AddLast(list, 3);
            Console.WriteLine("Printing list:");
            PrintList(list);
        }

        // 14. בדיקת הסרת כפילויות מהרשימה
        public static void TestRemoveDuplicates()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            AddLast(list, 2);
            Console.WriteLine("Before RemoveDuplicates: " + list);
            RemoveDuplicates(list);
            Console.WriteLine("After RemoveDuplicates: " + list);
        }

        // 15. בדיקת יצירת רשימה חדשה ללא כפילויות
        public static void TestCreateListWithoutDuplicates()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            AddLast(list, 2);
            Node<int> newList = CreateListWithoutDuplicates(list);
            Console.WriteLine("New list without duplicates: " + newList);
        }

        // 16. בדיקת העתקת הרשימה לכתובת זיכרון שונה
        public static void TestCopyList()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            Node<int> copiedList = CopyList(list);
            Console.WriteLine("Copied list: " + copiedList);
        }


        // 17. בדיקת היפוך הרשימה
        public static void TestReverseList()
        {
            Node<int> list = new Node<int>(1);
            AddLast(list, 2);
            AddLast(list, 3);
            Console.WriteLine("Before ReverseList: " + list);
            list = ReverseList(list);
            Console.WriteLine("After ReverseList: " + list);
        }

        // 18. בדיקת מיון הרשימה בסדר עולה
        public static void TestSortList()
        {
            Node<int> list = new Node<int>(3);
            AddLast(list, 1);
            AddLast(list, 2);
            Console.WriteLine("Before SortList: " + list);
            list = SortList(list);
            Console.WriteLine("After SortList: " + list);
        }

        // 19. בדיקת השוואת שתי רשימות
        public static void TestAreListsEqual()
        {
            Node<int> list1 = new Node<int>(1);
            AddLast(list1, 2);
            AddLast(list1, 3);

            Node<int> list2 = new Node<int>(1);
            AddLast(list2, 2);
            AddLast(list2, 3);

            Console.WriteLine("Lists are equal: " + AreListsEqual(list1, list2));
        }

        // 20. בדיקת מיזוג שתי רשימות
        public static void TestMergeLists()
        {
            Node<int> list1 = new Node<int>(1);
            AddLast(list1, 2);

            Node<int> list2 = new Node<int>(3);
            AddLast(list2, 4);

            Node<int> mergedList = MergeLists(list1, list2);
            Console.WriteLine("Merged list: " + mergedList);
        }

        // 21. בדיקת מיזוג רשימות ללא כפילויות
        public static void TestMergeListsNoDuplicates()
        {
            Node<int> list1 = new Node<int>(1);
            AddLast(list1, 2);
            AddLast(list1, 2);

            Node<int> list2 = new Node<int>(2);
            AddLast(list2, 3);

            Node<int> mergedList = MergeListsNoDuplicates(list1, list2);
            Console.WriteLine("Merged list without duplicates: " + mergedList);
        }

        // 22. בדיקת חיתוך רשימות
        public static void TestIntersectLists()
        {
            Node<int> list1 = new Node<int>(1);
            AddLast(list1, 2);
            AddLast(list1, 3);

            Node<int> list2 = new Node<int>(2);
            AddLast(list2, 3);
            AddLast(list2, 4);

            Node<int> intersectedList = IntersectLists(list1, list2);
            Console.WriteLine("Intersected list: " + intersectedList);
        }

        // 23. בדיקת פונקציות על רשימות מסוג Node<int> ו-Node<Worker>
        public static void TestFunctionsOnIntAndWorkerLists()
        {
            Node<int> intList = new Node<int>(1);
            AddLast(intList, 2);
            Console.WriteLine("Int List: " + intList);
            Console.WriteLine("Int List Length: " + GetLength(intList));

            Node<Worker> workerList = new Node<Worker>(new Worker("John", 5000));
            AddLast(workerList, new Worker("Jane", 6000));
            Console.WriteLine("Worker List: " + workerList);
            Console.WriteLine("Worker List Length: " + GetLength(workerList));
        }

        // 24. בדיקת הדפסת ממוצע הציונים של כל סטודנט ברשימה
        public static void TestPrintStudentGradesAverage()
        {
            Node<Course> courses1 = new Node<Course>(new Course("Math", 80));
            AddLast(courses1, new Course("History", 90));
            AddLast(courses1, new Course("Biology", 85));

            Node<Student> students = new Node<Student>(new Student("Alice", courses1));
            Console.WriteLine("Student Grades Average:");
            PrintStudentGradesAverage(students);
        }

        // 25. בדיקת החזרת הסטודנטים המצטיינים מכל כיתה
        public static void TestGetTopStudents()
        {
            Node<Course> courses1 = new Node<Course>(new Course("Math", 80));
            AddLast(courses1, new Course("History", 90));

            Node<Course> courses2 = new Node<Course>(new Course("Math", 60));
            AddLast(courses2, new Course("History", 75));

            Node<Student[]>[] classes = new Node<Student[]>[1];
            Student[] class1 = { new Student("Alice", courses1), new Student("Bob", courses2) };
            classes[0] = new Node<Student[]>(class1);

            Console.WriteLine("Top Students from Each Class:");
            Node<Student> topStudents = GetTopStudents(classes);
            PrintList(topStudents);
        }

        // 26. בדיקת החזרת סטודנטים עם הכי הרבה נכשלים מכל כיתה
        public static void TestGetStudentsWithMostFails()
        {
            Node<Course> courses1 = new Node<Course>(new Course("Math", 50));
            AddLast(courses1, new Course("History", 55));

            Node<Course> courses2 = new Node<Course>(new Course("Math", 60));
            AddLast(courses2, new Course("History", 40));

            Node<Student> students1 = new Node<Student>(new Student("Alice", courses1));
            Node<Student> students2 = new Node<Student>(new Student("Bob", courses2));

            Node<Student>[] studentLists = { students1, students2 };

            Console.WriteLine("Students with Most Fails:");
            Node<Student> studentsWithMostFails = GetStudentsWithMostFails(studentLists);
            PrintList(studentsWithMostFails);
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

       
        //23.  בדיקת פונקציות על רשימות מסוג Node<int> ו-Node<Worker>
        // הפונקציה מדפיסה בדיקות של כל הפונקציות הקיימות על רשימות של מספרים ועובדים
        public static void TestFunctionsOnLists()
        {
            // רשימת מספרים שלמים
            Node<int> intList = new Node<int>(1);
            AddLast(intList, 2);
            AddLast(intList, 3);
            Console.WriteLine("Int List: " + intList);
            Console.WriteLine("Int List Length: " + GetLength(intList));

            // רשימת עובדים
            Node<Worker> workerList = new Node<Worker>(new Worker("John", 5000));
            AddLast(workerList, new Worker("Jane", 6000));
            Console.WriteLine("Worker List: " + workerList);
            Console.WriteLine("Worker List Length: " + GetLength(workerList));
        }

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
        public static Node<Student> GetTopStudents(Node<Student[]>[] classList)
        {
            Node<Student> topStudents = null;

            for (int i = 0; i < classList.Length; i++)
            {
                Student[] students = classList[i].GetValue();
                Student topStudent = null;
                double highestAverage = -1;

                foreach (Student student in students)
                {
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
            }

            return topStudents;
        }

        //26. החזרת סטודנטים עם הכי הרבה נכשלים מכל כיתה
        // הפונקציה מחזירה את הסטודנטים בעלי מספר הכשלונות הגבוה ביותר מכל רשימה בכיתה
        public static Node<Student> GetStudentsWithMostFails(Node<Student>[] studentLists)
        {
            Node<Student> failedStudents = null;

            foreach (Node<Student> studentList in studentLists)
            {
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
            }

            return failedStudents;
        }

    }
}
