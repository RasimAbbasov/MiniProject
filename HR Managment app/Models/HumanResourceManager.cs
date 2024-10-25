using System.ComponentModel.Design;
using System.Threading.Channels;
using System.Xml.Linq;

namespace HR_Managment_app.Models
{
    internal class HumanResourceManager : IHumanResourceManager
    {

        public List<Department> Departments{ get; private set; } =new List<Department>();
        public void AddDepartment(string departmentname, int workerlimit, decimal salarylimit)
        {
            var department = new Department(departmentname, workerlimit, salarylimit);
            Departments.Add(department);
        }
        public void GetDepartments()
        {
            foreach (var item in Departments)
            {
                Console.WriteLine($"Department Name:{item.Name} Worker limit:{item.WorkerLimit} Salary limit:{item.SalaryLimits}");
            }
        }

        //public List<Department> GetDepartments()
        //{
        //    return Departments;
        //}


        //public void EditDepartments(string name1, string name2)
        //{
        //    //if (department == null) throw new ArgumentNullException();
        //    //department.Name = name;
        //    if(name2.Length<2) throw new ArgumentNullException("name cant be null");
        //    foreach (var item in Departments) 
        //    {
        //     if(item.Name == name1) 
        //        {
        //            name1 = name2;
        //        }
        //    }

        //}
        public void EditDepartments(string departmentname, string name)
        {
            var editname=Departments.Find(x => x.Name.ToLower()==departmentname.ToLower());
            if (editname == null) { throw new ArgumentNullException(); }
            editname.Name = name;
        }
        public void AddEmployee(string fullname, string position, decimal salary, string departmentname)
        {
            var department = Departments.FirstOrDefault(d => d.Name.Equals(departmentname, StringComparison.OrdinalIgnoreCase));
            if (department == null) { throw new ArgumentNullException(); }
            Employee employee = new Employee(fullname, position, salary, departmentname);
            department.Employees.Add(employee);
        }

        //public void AddEmployee(string No,string fullname, string position, decimal salary, string departmentname)
        //{
        //    if (fullname.Length < 2) throw new ArgumentException("FullName 2-den az herfden ibaret ola bilmez");
        //    Employee employee = new Employee(No, fullname, position,salary,departmentname);
        //    Employees.Add(employee);
        //}
        public void RemoveEmployee(string name, string departmentname) 
        {
            var department = Departments.FirstOrDefault(d => d.Name.Equals(departmentname, StringComparison.OrdinalIgnoreCase));
            if (department != null)
            {
                var employee = department.Employees.FirstOrDefault(e => e.FullName.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (employee != null)
                    department.Employees.Remove(employee);
                else
                {
                    throw new ArgumentException("Employee tapilmadi");
                }
            }
        }
        public void EditEmployee(string name, string position,decimal salary)
        {
            if (salary < 250) 
               throw new ArgumentException("Salary minimum 250-den asagi ola bilmez");
            if (position.Length < 2)
                throw new ArgumentException("Position minimum 2 hərfdən ibarət olmalıdır.");
            foreach (var department in Departments)
            {
                var employee = department.Employees.FirstOrDefault(x => x.FullName.Equals(name,StringComparison.OrdinalIgnoreCase));
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
            var foundEmployees = Departments.SelectMany(d => d.Employees)
                                      .Where(e => e.FullName.Contains(name, StringComparison.OrdinalIgnoreCase))
                                      .ToList();

            if (foundEmployees.Count == 0)
            {
                Console.WriteLine("Employee tapilmadi!");
                return;
            }

            Console.WriteLine("Founded employees:");
            foreach (var employee in foundEmployees)
            {
                Console.WriteLine($"Employee No:{employee.No}, Ad: {employee.FullName}, Position: {employee.Position}, Salary: {employee.Salary}, Department: {employee.DepartmentName}");
            }
        }
    }
}
