using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListPrj
{
    internal class Course
    {
        private string courseCode;
        private double grade;

        public Course(string courseCode, double grade)
        {
            SetCourseCode(courseCode);
            SetGrade(grade);
        }

        public string GetCourseCode()
        {
            return courseCode;
        }

        public void SetCourseCode(string courseCode)
        {
            this.courseCode = courseCode;
        }

        public double GetGrade()
        {
            return grade;
        }

        public void SetGrade(double grade)
        {
            this.grade = grade;
        }

        public override string ToString()
        {
            return $"Course Code: {courseCode}, Grade: {grade}";
        }
    }
}
