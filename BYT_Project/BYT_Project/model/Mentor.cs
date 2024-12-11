using System.ComponentModel.DataAnnotations;
using BYT_Project.Utils;
using BYT_Project.Utils.Exceptions;
using BYT_Project.Utils.Validation;

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

        public Mentor(int salary, string experience, DateTime dateOfEmployment, string name, string surname, string email, DateTime dateOfBirth, DateTime createdAt, string specialization, Mentor mentor) : base(salary, experience, dateOfEmployment, name, surname, email, dateOfBirth, createdAt)
        {
            Specialization = specialization;
            Chief = mentor;

            CustomValidator.Validate(this);

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

        public void AddChief(Mentor mentor)
        {
            try
            {
                if (mentor == this) throw new RecursiveChiefException();
                Chief = mentor;
            }
            catch(RecursiveChiefException e) { }
        }

        public void AddCourse(Course course, string role)
        {
            try
            {
                if (Courses.Contains(course)) throw new ReverseConnectionException();
                Courses.Add(course);
                course.AddMentor(role, this);
            }
            catch (ReverseConnectionException e) { }
        }

        public static Mentor? Create(int salary, string experience, DateTime dateOfEmployment, string name, string surname, string email, DateTime dateOfBirth, string specialization)
        {
            try
            {
                return new Mentor(salary, experience, dateOfEmployment, name, surname, email, dateOfBirth, DateTime.Now, specialization, null);
            }
            catch (ValidationException e)
            {
                return null;
            }
        }
    }
}