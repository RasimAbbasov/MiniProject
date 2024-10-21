namespace HR_Managment_app.Models
{
    internal class HumanResourceManager : IHumanResourceManager
    {

        public List<Department> Departments{ get; }=new List<Department>();
        public void AddDepartment(string departmentName, int workerlimit, decimal salarylimit)
        {
            if (departmentName.Length < 2) throw new ArgumentException("Department name 2-den az herfden ibaret ola bilmez");
            Department department = new Department(departmentName, workerlimit, salarylimit);
            Departments.Add(department);
        }
        public void GetDepartments()
        {
            foreach (var item in Departments)
            {
                Console.WriteLine($"Department Name:{item.Name} Worker limit:{item.WorkerLimit} Salary limit:{item.SalaryLimits}");
            }
        }

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
