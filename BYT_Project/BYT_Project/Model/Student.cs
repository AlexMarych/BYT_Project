using BYT_Project.Utils;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class Student : Person
    {
        [Range(0, int.MaxValue)]
        public int Balance { get; set; }

        [Range(0, 5)]
        public int Gpa { get; }
        public List<Petition>? Petitions { get; set; }
        public List<Course>? Courses { get; set; }
        public List<StudentTest>? StudentTests { get; set; }
        private static List<Student> _extent = [];

        static Student()
        {
            _extent = ExtentManager.LoadExtent<Student>();
        }

        public Student(string name, string surname, string email, DateTime dateOfBirth, DateTime createdAt, int balance, List<StudentTest> studentTests) : base(name, surname, email, dateOfBirth, createdAt)
        {
            Balance = balance;
            StudentTests = studentTests;
            Gpa = StudentTests != null && StudentTests.Count != 0 ? StudentTests.Sum(x => x.Grade) / StudentTests.Count : 0;

            CutsomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<Student>();
            ExtentManager.SaveExtent(_extent);
        }

        public override string ToString()
        {
            return base.ToString() + $" Balance: {Balance}, Gpa: {Gpa}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Student student &&
                   Id == student.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}