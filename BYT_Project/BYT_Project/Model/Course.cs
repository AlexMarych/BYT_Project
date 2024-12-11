using BYT_Project.Utils;
using BYT_Project.Utils.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    [Serializable]
    public abstract class Course
    {
        public long Id { get; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public enum DifficultyLevel
        {
            Beginner,
            Intermidiate,
            Advanced
        }

        public DifficultyLevel difficultyLevel { get; set; }

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        public List<Payment> Payments { get; set; }
        public IDictionary<string, Mentor>? Mentors { get; set; }

        public List<Test>? Tests { get; set; }
        protected Course(string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel difficulty, List<Test>? tests)
        {
            Name = name;
            Price = price;
            Mentors = mentors;
            difficultyLevel = difficulty;
            Tests = tests;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Course course &&
                   Id == course.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public virtual bool AddMentor(string role, Mentor mentor)
        {
            Mentors ??= new Dictionary<string, Mentor>();
            mentor.Courses ??= [];

            if (mentor.Courses.Contains(this) || Mentors.ContainsKey(role))
                return false;

            Mentors.Add(role, mentor);
            mentor.AddCourse(this, role);

            return true;
        }

        public virtual bool AddPayment(Student student)
        {
            Payment pay = Payment.Create(student, this);

            Payments ??= [];
            student.Payments ??= [];

            if (Payments.Contains(pay) || student.Payments.Contains(pay))
                return false;

            Payments.Add(pay);
            student.AddPayment(this);

            return true;
        }
    }
}