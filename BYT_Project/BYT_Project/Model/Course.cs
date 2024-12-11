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

        public virtual void AddMentor(string role, Mentor mentor)
        {
            try
            {
                if (Mentors.ContainsKey(role)) throw new ReverseConnectionException();

                this.Mentors.Add(role, mentor);

                mentor.AddCourse(this, role);
            }
            catch (ReverseConnectionException e) { }
        }

        public void AddPayment(Student student)
        {
            try
            {
                Payment pay = Payment.Create(student, this);
                this.Payments.Add(pay);
                if (student.Payments.Contains(pay)) throw new ReverseConnectionException();
                student.AddPayment(this);
            }
            catch (ReverseConnectionException e) { }
        }
    }
}