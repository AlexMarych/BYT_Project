
namespace BYT_Project.Model
{
    public class Student : Person
    {
        public Student(string name, string surname, DateTime dateOfBirth, DateTime createdAt) : base(name, surname, dateOfBirth, createdAt)
        {
        }

        public int Balance { get; set; }
        public int Gpa { get; set; }
        public List<Petition>? Petitions { get; set; }
        public List<Course>? Courses { get; set; }

        
    }
}