
namespace BYT_Project.Model
{
    public class Support : Employee
    {
        public Support(int salary, string experience, DateTime dateOfEmployment, string name, string surname, DateTime dateOfBirth, DateTime createdAt) : base(salary, experience, dateOfEmployment, name, surname, dateOfBirth, createdAt)
        {
        }

        public List<Petition>? Petitions { get; set; }


    }
}