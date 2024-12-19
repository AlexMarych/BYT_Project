using BYT_Project.Utils;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace BYT_Project.Model
{
    public class Support : Employee
    {
        public List<Petition> Petitions { get; set; } = [];

        [Range(0, int.MaxValue)]
        public int SalaryBonus { get; }
        private static readonly float SALARY_MULTIPLIER = 0.005f;
        public static List<Support> _extent = [];

        static Support()
        {
            _extent = ExtentManager.LoadExtent<Support>();
        }

        public Support(int salary, string experience, DateTime dateOfEmployment, string name, string surname, string email, DateTime dateOfBirth, DateTime createdAt, List<Petition>? petitions) : base(salary, experience, dateOfEmployment, name, surname, email, dateOfBirth, createdAt)
        {
            Petitions = petitions;
            SalaryBonus = (int)(Petitions.Count * SALARY_MULTIPLIER * Salary);
            CustomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<Support>();
            ExtentManager.SaveExtent(_extent);
        }

        public static Support? Create(int salary, string experience, DateTime dateOfEmployment, string name, string surname, string email, DateTime dateOfBirth)  
        {
            try
            {
                return new Support(salary, experience, dateOfEmployment, name, surname, email, dateOfBirth, DateTime.Now, null);
            }
            catch
            {
                return null;
            }
        }

        public static void Modify(Support support)
        {

            Support modifiyable = _extent.First(x => x.Id == support.Id);

            _extent.Remove(modifiyable);

            ExtentManager.ClearExtent<Support>();
            ExtentManager.SaveExtent(_extent);
        }

        public static void Delete(Support support)
        {
            _extent.Remove(support);
            ExtentManager.ClearExtent<Support>();
            ExtentManager.SaveExtent(_extent);
        }

        public bool AddPetition(Petition petition)
        {
            Petitions ??= [];

            if (petition.Support == this || Petitions.Contains(petition))
                return false;

            Petitions.Add(petition);
            petition.AddSupport(this);

            ExtentManager.ClearExtent<Student>();
            ExtentManager.SaveExtent(_extent);

            return true;
        }

        public override bool Equals(object? obj)
        {
            return obj is Support support &&
                   Id == support.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}