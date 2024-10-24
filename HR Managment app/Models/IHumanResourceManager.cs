namespace HR_Managment_app.Models
{
    internal interface IHumanResourceManager
    {
         List<Department> Departments { get; }
        void AddDepartment(string name, int workerlimit, decimal salarylimits);
        void GetDepartments();
        void EditDepartments(string name, string newname);
        void AddEmployee(string fullname, string position, decimal salary, string departmentname);
        void RemoveEmployee(string employeeno, string departmentName);
        void EditEmployee(string employeeno, decimal salary, string position);
        void Search(string name);
    }
}
