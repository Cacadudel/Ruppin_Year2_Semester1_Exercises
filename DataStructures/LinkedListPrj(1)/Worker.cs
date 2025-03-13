using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LinkedListPrj
{
    internal class Worker : IComparable
    {
        private string name;
        private double salary;
        public Worker(string name, double salary)
        {
            SetName(name);
            SetSalary(salary);
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public double GetSalary()
        {
            return salary;
        }
        public void SetSalary(double salary)
        {
            this.salary = salary;
        }
        public override string ToString()
        {
            return $"Worker: {name}, Salary: {salary}";
        }

        // שימוש בפונקצית השוואה מהINTERFACE
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Worker other = obj as Worker;
            if (other == null)
                throw new ArgumentException("Object is not a Worker");

            return this.salary.CompareTo(other.salary);
        }
    }
}