namespace BYT_Project.model
{
    public class Mentor : Employee
    {
        public required string Specialization { get; set; }
        public Mentor? Chief { get; set; }
    }
}