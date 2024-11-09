using System.ComponentModel.DataAnnotations;
using BYT_Project.Utils;

namespace BYT_Project.Model
{
    public class Mentor : Employee
    {
        [Required(AllowEmptyStrings = false)]
        public string Specialization { get; set; }
        public Mentor? Chief { get; set; }
        public List<Course>? Courses { get; set; }
        public static List<Mentor> _extent = [];

        static Mentor()
        {
            _extent = ExtentManager.LoadExtent<Mentor>();
        }

        public Mentor(int salary, string experience, DateTime dateOfEmployment, string name, string surname, DateTime dateOfBirth, DateTime createdAt, string specialization) : base(salary, experience, dateOfEmployment, name, surname, dateOfBirth, createdAt)
        {
            Specialization = specialization;

            CutsomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<Mentor>();
            ExtentManager.SaveExtent(_extent);
        }

        public override string ToString()
        {
            return base.ToString() + $"Specialization: {Specialization}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Mentor mentor &&
                   base.Equals(obj) &&
                   Id == mentor.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id);
        }
    }
}