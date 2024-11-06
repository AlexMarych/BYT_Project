using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public abstract class Employee : Person
    {
        [Range(0, int.MaxValue)]
        public int Salary { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Experience { get; set; }

        public DateTime DateOfEmployment { get; set; }

        protected Employee(int salary, string experience, DateTime dateOfEmployment, string name, string surname, DateTime dateOfBirth, DateTime createdAt)
            : base(name, surname, dateOfBirth, createdAt)
        {
            Salary = salary;
            Experience = experience;
            DateOfEmployment = dateOfEmployment;
        }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {Salary}, Experience: {Experience}, DateOfEmployment: {DateOfEmployment.ToString("yyyy-MM-dd HH:mm:ss")}";
        }
    }
}