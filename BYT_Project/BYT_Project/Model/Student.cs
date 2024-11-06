using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class Student : Person
    {
        [Range(0, int.MaxValue)]
        public int Balance { get; set; }

        [Range(0, 5)]
        public int Gpa { get; set; }
        public List<Petition>? Petitions { get; set; }
        public List<Course>? Courses { get; set; }
        private static List<Student> _extent = [];

        public Student(string name, string surname, DateTime dateOfBirth, DateTime createdAt, int balance, int gpa) : base(name, surname, dateOfBirth, createdAt)
        {
            Balance = balance;
            Gpa = gpa;

            _extent.Add(this);
        }

        public override string ToString()
        {
            return base.ToString() + $" Balance: {Balance}, Gpa: {Gpa}";
        }

    }
}