using BYT_Project.Utils;

namespace BYT_Project.Model
{
    public class Support : Employee
    {
        public List<Petition>? Petitions { get; set; }
        public int salaryBonus { get; set; }
        private static List<Support> _extent = [];

        static Support()
        {
            _extent = ExtentManager.LoadExtent<Support>();
        }

        public Support(int salary, string experience, DateTime dateOfEmployment, string name, string surname, DateTime dateOfBirth, DateTime createdAt) : base(salary, experience, dateOfEmployment, name, surname, dateOfBirth, createdAt)
        {
            CutsomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<Support>();
            ExtentManager.SaveExtent(_extent);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}