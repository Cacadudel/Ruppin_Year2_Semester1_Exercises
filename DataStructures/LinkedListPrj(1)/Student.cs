using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPrj
{
    internal class Student
    {
        private string name;
        private Node<Course> courses;

        public Student(string name, Node<Course> courses = null)
        {
            SetName(name);
            SetCourses(courses);
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public Node<Course> GetCourses()
        {
            return courses;
        }

        public void SetCourses(Node<Course> courses)
        {
            this.courses = courses;
        }

        public override string ToString()
        {
            return $"Student: {name}, Courses: {(courses != null ? courses.ToString() : "No Courses")}";
        }
    }
}
