using HR_Managment_app.Models;

namespace HR_Managment_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            humanResourceManager.AddDepartment("department1", 1, 1000);
            humanResourceManager.AddDepartment("department3", 2, 2000);
            humanResourceManager.AddDepartment("department2", 3, 5000);

            humanResourceManager.GetDepartments();
            humanResourceManager.EditDepartments("department1","NEW NAME");
            humanResourceManager.GetDepartments();
        }
    }
}
