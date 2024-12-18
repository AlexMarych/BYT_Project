using BYT_Project.Utils;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    [Serializable]
    public class Petition
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Text { get; set; }

        public enum StatusType
        {
            Opened,
            Closed
        }
        public StatusType Status { get; set; }

        public Student Student { get; set; }
        public Support Support { get; set; }

        public static List<Petition> _extent = [];

        static Petition()
        {
            _extent = ExtentManager.LoadExtent<Petition>();
        }

        public Petition(Student student ,string text, StatusType status)
        {
            Student = student;
            Text = text;
            Status = status;

            CustomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<Petition>();
            ExtentManager.SaveExtent(_extent);
        }

        public static Petition? Create(Student student, string text, StatusType status)
        {
            try
            {
                return new Petition(student, text, status);
            }
            catch (ValidationException)
            {
                return null;
            }
        }

        public static void Modifiy(Petition petition)
        {

            Petition modifiyable = _extent.First(x => x.Id == petition.Id);

            _extent.Remove(modifiyable);
            _extent.Add(petition);

            ExtentManager.ClearExtent<Petition>();
            ExtentManager.SaveExtent(_extent);
        }
        public static void Delete(Petition petition)
        {
            _extent.Remove(petition);
            ExtentManager.ClearExtent<Petition>();
            ExtentManager.SaveExtent(_extent);
        }

        public bool AddStudent(Student student)
        {
            Student = student;
            student.Petitions ??= [];

            if (student.Petitions.Contains(this))
                return false;

            student.AssignPetition(this);
            ExtentManager.ClearExtent<Petition>();
            ExtentManager.SaveExtent(_extent);

            return true;
        }

        public bool AddSupport(Support support)
        {
            Support = support;
            support.Petitions ??= [];

            if (support.Petitions.Contains(this))
                return false;

            support.AddPetition(this);
            ExtentManager.ClearExtent<Petition>();
            ExtentManager.SaveExtent(_extent);

            return true;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Text: {Text}, Status: {Status}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Petition petition &&
                   Id == petition.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}