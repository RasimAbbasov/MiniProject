using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Managment_app.Models
{
    internal class HumanResourceManager : IHumanResourceManager
    {

        public List<Department> Departments { get; set; }
        public HumanResourceManager()
        {
            Departments = new List<Department>();
        }
        public void AddDepartment(string departmentName, int workerlimit, decimal salarylimit)
        {
            if (departmentName.Length < 2) throw new ArgumentException("Department name 2-den az herfden ibaret ola bilmez");
            Department department = new Department(departmentName, workerlimit, salarylimit);
            department.Name = departmentName;
            department.WorkerLimit = workerlimit;
            department.SalaryLimits = salarylimit;
            Departments.Add(department);

        }
        public List<Department> GetDepartments()
        {
            return Departments;
        }

        public void EditDepartments(Department department, string name)
        {
            if (department == null) throw new ArgumentNullException();
            department.Name = name;
        }
        public void EditDepartments(string departmentname, string name)
        {
            var editname=Departments.Find(x => x.Name.ToLower()==name.ToLower());
            if (editname == null) throw new ArgumentNullException();
            editname.Name = name;
        }
        public void AddEmployee(Employee employee,string departmentname)
        {
            
            var existing=Departments.Find(c => c.Name == departmentname);
            if (existing == null) { throw new ArgumentNullException(); }
             existing.Employees.Add(employee);
        }
        public void RemoveEmployee(string employeeNo, string departmentname) 
        {
            var existing = Departments.Find(c => c.Name == departmentname);
            var removeEmployee=existing.Employees.Find(x=>x.No==employeeNo);
            if (existing == null || removeEmployee ==null ) { throw new ArgumentNullException("Tapilmadi"); }
            existing.Employees.Remove(removeEmployee);

        }
        public void EditEmployee(string no, decimal salary, string position)
        {
            if (salary < 250) 
               throw new ArgumentException("Salary minimum 250-den asagi ola bilmez");
            if (position.Length < 2)
                throw new ArgumentException("Position minimum 2 hərfdən ibarət olmalıdır.");
            Employee employee;
            foreach (var department in Departments)
            {
                employee = department.Employees.Find(x => x.No == no);
                if (employee == null)
                {
                    throw new ArgumentException("No uygun deyil");
                }
                employee.Position = position;
                employee.Salary = salary;
            }
           
        }
        public void Search(string name)
        {
            foreach (var item in Departments.SelectMany(d => d.Employees)) 
            {
                if(item.FullName.Contains(name))
                Console.WriteLine(item);
            }    
        }
    }
}
