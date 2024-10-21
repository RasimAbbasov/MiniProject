using System.Runtime.CompilerServices;

namespace HR_Managment_app.Models
{
    public class Employee
    {
        public string No { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string DepartmentName { get; set; }
        public Employee(string no,string fullname,string postion,decimal salary)
        {
            if (salary < 250)
                throw new ArgumentException("Salary 250-den az ola bilmez.");
            if (Position.Length < 2)
                throw new ArgumentException("Position 2-den az herfden az ola bilmez.");
            No = no;
            FullName = fullname;
            Position = postion;
            Salary = salary;
        }

    }
}
