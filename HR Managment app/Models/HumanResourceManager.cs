namespace HR_Managment_app.Models
{
    internal class HumanResourceManager : IHumanResourceManager
    {
        private int _employeeCounter = 1001;
        public List<Department> Departments{ get; private set; } =new List<Department>();
        public void AddDepartment(string departmentname, int workerlimit, decimal salarylimit)
        {
            var department = new Department(departmentname, workerlimit, salarylimit);
            Departments.Add(department);
            Console.WriteLine($"{department.Name} added to Departments list succesfully!");
        }
        public void GetDepartments()
        {
            int deparmentcount = 1;
            Console.WriteLine("Information about departments:");
            foreach (var item in Departments)
            {
                Console.WriteLine($"{deparmentcount}. Department Name:{item.Name} Worker limit:{item.WorkerLimit} Salary limit:{item.SalaryLimits}");
                deparmentcount++;
            }
        }
        public void EditDepartments(string departmentname, string name)
        {
            var editname=Departments.Find(x => x.Name.ToLower()==departmentname.ToLower());
            if (editname == null) { throw new ArgumentNullException(); }
            editname.Name = name;
            Console.WriteLine($"{departmentname} department edited to {name}");
        }
        public void AddEmployee(string fullname, string position, decimal salary, string departmentname)
        {
            var department = Departments.FirstOrDefault(d => d.Name.Equals(departmentname, StringComparison.OrdinalIgnoreCase));
            if (department == null) { throw new ArgumentNullException(); }
            string employeeNumber = EmployeeNumber(department.Name);
            if (salary > department.SalaryLimits) { throw new ArgumentException($"Employee salary can't be more than {department.Name} department salary limit!"); }
            Employee employee = new Employee(employeeNumber,fullname, position, salary, departmentname);
            department.Employees.Add(employee);
            Console.WriteLine($"{fullname} added as an employee.");
        }
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
                    throw new ArgumentException("Employee not found!");
                }
            }
        }
        public void EditEmployee(string no, string position,decimal salary)
        {
            if (salary < 250) 
               throw new ArgumentException("Salary must be more than 250!");
            if (position.Length < 2)
                throw new ArgumentException("Position must be more than 2 words!");
            foreach (var department in Departments)
            {
                var employee = department.Employees.FirstOrDefault(x => x.No.Equals(no, StringComparison.OrdinalIgnoreCase));
                if (employee != null)
                {
                    employee.Position = position;
                    employee.Salary = salary;
                    Console.WriteLine($"{employee.FullName}'s position changed to {position} and new salary is {salary}.");
                }
            }                 
        }
        public void Search(string name)
        {
            var foundEmployees = Departments.SelectMany(d => d.Employees)
                                      .Where(e => e.FullName.Contains(name, StringComparison.OrdinalIgnoreCase))
                                      .ToList();

            if (foundEmployees.Count == 0)
            {
                Console.WriteLine("Employee not found!");
                return;
            }

            Console.WriteLine("Founded employees:");
            foreach (var employee in foundEmployees)
            {
                Console.WriteLine($"\nEmployee No:{employee.No}, Fullname: {employee.FullName}, Position: {employee.Position}, Salary: {employee.Salary}, Department: {employee.DepartmentName}");
            }
        }
        private string EmployeeNumber(string departmentName)
        {
            string prefix = departmentName.Substring(0, 2).ToUpper();
            return $"{prefix}{_employeeCounter++:D4}";
        }
    }
}
