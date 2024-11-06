using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class Mentor : Employee
    {
        [Required(AllowEmptyStrings = false)]
        public string Specialization { get; set; }
        public Mentor? Chief { get; set; }
        public List<Course>? Courses { get; set; }
        public static List<Mentor> _extent = [];

        public Mentor(int salary, string experience, DateTime dateOfEmployment, string name, string surname, DateTime dateOfBirth, DateTime createdAt, string specialization) : base(salary, experience, dateOfEmployment, name, surname, dateOfBirth, createdAt)
        {
            Specialization = specialization;

            _extent.Add(this);
            ExtentManager.SaveExtent(_extent);
        }

        public override string ToString()
        {
            return base.ToString() + $"Specialization: {Specialization}";
        }
    }
}