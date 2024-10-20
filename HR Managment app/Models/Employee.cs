using System.Runtime.CompilerServices;

namespace HR_Managment_app.Models
{
    public class Employee
    {
        public string No { get; set; }
        public string FullName { get; set; }

        private string _position;
        public string Position
        {
            get => _position;
            set
            {
                if (value.Length < 2)
                    throw new ArgumentException("Position minimum 2 hərfdən ibarət olmalıdır.");
                _position = value;
            }
        }
        private decimal _salary;
        public decimal Salary 
        {
            get => _salary;
            set 
            {
                if (value < 250)  throw new ArgumentException("Salary minimum 250-den asagi ola bilmez");
                _salary = value;      
            }
        }
        public string DepartmentName { get; set; }
        public Employee(string no,string fullname,string postion,decimal salary)
        {
            No = no;
            FullName = fullname;
            _position = postion;
            _salary = salary;
        }

    }
}
