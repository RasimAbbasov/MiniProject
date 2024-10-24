using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace HR_Managment_app.Models
{
    public class Employee
    {
        private static int employeecounter = 1000;

        private static readonly Regex employeeNumberRegex = new Regex(@"^[A-Z]{2}\d{4}$");
        public string No { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string DepartmentName { get; set; }
        public Employee(string fullname,string position,decimal salary,string departmentname)
        {
            if (salary < 250)
                throw new ArgumentException("Salary 250-den az ola bilmez.");
            if (position.Length < 2)
                throw new ArgumentException("Position 2-den az herfden az ola bilmez.");

            //No = $"{DepartmentName.Substring(0, 2).ToUpper()}{employeecounter++}";
            FullName = fullname;
            Position = position;
            Salary = salary;
            DepartmentName = departmentname;
        }
        public static bool IsValidEmployeeNumber(string employeeNumber)
        {
            return employeeNumberRegex.IsMatch(employeeNumber);
        }

    }
}
