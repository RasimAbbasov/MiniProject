using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public Employee(string no,string fullname,string position,decimal salary,string departmentname)
        {
            if (salary < 250)
                throw new ArgumentException("Salary must be more than 250 ");
            if (position.Length < 2)
                throw new ArgumentException("Position 2-den az herfden az ola bilmez.");
            if(!IsValidEmployeeNumber(no))
                throw new ArgumentException("Invalid employee number format.");
            No = no;
            FullName = fullname;
            Position = position;
            Salary = salary;
            DepartmentName = departmentname;
        }
        private bool IsValidEmployeeNumber(string number)
        {
            return Regex.IsMatch(number, @"^[A-Z]{2}\d{4}$");
        }

    }
}
