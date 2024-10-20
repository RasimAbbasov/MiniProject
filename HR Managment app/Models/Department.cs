using System.Linq.Expressions;
using System.Numerics;

namespace HR_Managment_app.Models
{
    public class Department
    {
        private string _name;
        public string Name 
        { get => _name; 
            set 
            { if (value.Length < 2) throw new ArgumentException("Department name 2-den az herfden ibaret ola bilmez");
             _name = value;
            }
        }
        public int WorkerLimit { get; set; }
        public decimal SalaryLimits { get; set; }
        public List<Employee> Employees;
        public Department(string name,int workerlimit,decimal salaryLimits)
        {
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimits=salaryLimits;
            Employees = new List<Employee>();
        }
        public void CalcSalaryAverage()
        {
            Employees.Average(e =>e.Salary);
        }                 
    }   
}
