namespace BYT_Project.Model
{
    public class Mentor : Employee
    {
        public required string Specialization { get; set; }
        public Mentor? Chief { get; set; }
        public List<Course>? Courses { get; set; }
    }
}