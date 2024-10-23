
using System;
using System.IO;


namespace BYT_Project.Model
{
    public class Employee : Person
    {
        public int Salary { get; set; }
        public string Experience { get; set; }
        public DateTime DateOfEmployment { get; set; }

        public static List<Employee> extent = new();

        public Employee(int salary, string experience, DateTime dateOfEmployment, string name, string surname, DateTime dateOfBirth, DateTime createdAt) : base(name, surname, dateOfBirth, createdAt)
        {
            Salary = salary;
            Experience = experience;
            DateOfEmployment = dateOfEmployment;

            extent.Add(this);
            string employeeExtentString = Newtonsoft.Json.JsonConvert.SerializeObject(extent);
            string path = @"Resources/ClassExtent/EmployeeExtent.txt";
            using (FileStream fs = File.Create(path))
            {
                System.IO.File.WriteAllText(path, employeeExtentString);
            }
        }
    }
}