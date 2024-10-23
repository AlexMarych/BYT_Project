namespace BYT_Project.Model
{
    public class Support : Employee
    {
        public List<Petition>? Petitions { get; set; }
        private static List<Support> _extent = [];

        public Support(int salary, string experience, DateTime dateOfEmployment, string name, string surname, DateTime dateOfBirth, DateTime createdAt) : base(salary, experience, dateOfEmployment, name, surname, dateOfBirth, createdAt)
        {
            _extent.Add(this);
            ExtentManager.SaveExtent(_extent);
        }
    }
}