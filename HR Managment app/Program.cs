using HR_Managment_app.Models;

namespace HR_Managment_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            //Employee employee01 = new Employee("502", "Seymur", "Junior backend", 300);
            humanResourceManager.AddDepartment("department1", 3, 500);
            humanResourceManager.AddDepartment("department3", 3, 500);
            humanResourceManager.AddDepartment("department2", 3, 500);

            //humanResourceManager.AddEmployee(employee01, "department1");
            Console.WriteLine(humanResourceManager.GetDepartments());
            //humanResourceManager.EditDepartments(department3, "Department 23");

        }
    }
}
