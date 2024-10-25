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
            humanResourceManager.EditDepartments("department1","department0010");
            humanResourceManager.AddEmployee("Rasim Abbasov","Backend",300,"department2");
            //humanResourceManager.EditEmployee("Rasim Abbasov","Frontend", 100000);
            humanResourceManager.Search("R");

            humanResourceManager.RemoveEmployee("Rasim Abbasov", "department2");
            humanResourceManager.Search("R");

            humanResourceManager.GetDepartments();
            //editemployee zamani employeeNo islemir,probleme cevrilib.
            //employee'ye No-yu elave etmek lazimdir

        }
    }
}
