using Newtonsoft.Json;

namespace BYT_Project.Model
{
    public class Employee : Person
    {
        public int Salary { get; set; }
        public string Experience { get; set; }
        public DateTime DateOfEmployment { get; set; }

        private static List<Employee> _extent = [];

        public Employee(int salary, string experience, DateTime dateOfEmployment, string name, string surname, DateTime dateOfBirth, DateTime createdAt)
            : base(name, surname, dateOfBirth, createdAt)
        {
            Salary = salary;
            Experience = experience;
            DateOfEmployment = dateOfEmployment;

            _extent.Add(this);

            ExtentManager.SaveExtent(_extent);
        }
    }
}