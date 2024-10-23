
namespace BYT_Project.Model
{
    public class Mentor : Employee
    {
        public string Specialization { get; set; }
        public Mentor? Chief { get; set; }
        public List<Course>? Courses { get; set; }

        public Mentor(int salary, string experience, DateTime dateOfEmployment, string name, string surname, DateTime dateOfBirth, DateTime createdAt, string specialization) : base(salary, experience, dateOfEmployment, name, surname, dateOfBirth, createdAt)
        {
            Specialization = specialization;
        }
    }
}