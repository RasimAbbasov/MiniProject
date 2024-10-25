using HR_Managment_app.Models;

namespace HR_Managment_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            humanResourceManager.AddDepartment("IT Security", 1, 1000);
            humanResourceManager.AddDepartment("Tech Support", 2, 2000);
            humanResourceManager.AddDepartment("Web Development", 3, 5000);
            Console.WriteLine("--------------------------------------------------");
            humanResourceManager.GetDepartments();
            Console.WriteLine("--------------------------------------------------");
            humanResourceManager.EditDepartments("Tech Support","Data Management");
            Console.WriteLine("--------------------------------------------------");
            humanResourceManager.AddEmployee("Rasim Abbasov", "Backend Intern", 4000,"Web Development");
            Console.WriteLine("--------------------------------------------------");
            humanResourceManager.Search("R");
            Console.WriteLine("--------------------------------------------------");
            humanResourceManager.EditEmployee("WE1001", "Frontend Intern", 3000);
            Console.WriteLine("--------------------------------------------------");
            humanResourceManager.Search("r");
            Console.WriteLine("--------------------------------------------------");
            humanResourceManager.GetDepartments();
        }
    }
}
