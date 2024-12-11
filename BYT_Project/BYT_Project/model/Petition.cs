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

        private static List<Petition> _extent = [];

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