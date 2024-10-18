namespace BYT_Project.Model
{
    public class Student : Person
    {
        public int Balance { get; set; }
        public int Gpa { get; set; }
        public List<Petition>? Petitions { get; set; }
        public List<Course>? Courses { get; set; }
    }
}