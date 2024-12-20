﻿namespace HR_Managment_app.Models
{
    public class Department
    {
        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public decimal SalaryLimits { get; set; }
        public List<Employee> Employees { get; private set; } = new List<Employee>();
        public Department(string name,int workerlimit,decimal salaryLimits)
        {
            if (name.Length < 2)
                throw new ArgumentException("Department must be more than 2!");
            if (salaryLimits < 250)
                throw new ArgumentException("Salary limits must be more than 250!");
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimits=salaryLimits;
        }
        public void CalcSalaryAverage()
        {
            Employees.Average(e =>e.Salary);
        }
        public override string ToString()
        { 
            return $"Department Name: {Name}, Worker Limit: {WorkerLimit}, Salary Limits: {SalaryLimits}";
        }

    }
}   
