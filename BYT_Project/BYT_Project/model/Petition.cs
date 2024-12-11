using BYT_Project.Utils;
using BYT_Project.Utils.Exceptions;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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
            this.Student = student; 
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
            catch (ValidationException e)
            {
                return null;
            }
        }

        public void AddStudent(Student student)
        {
            if (Student != null) throw new ReverseConnectionException();
            this.Student = student;

            if (student.Petitions.Contains(this)) throw new ReverseConnectionException();
            student.Petitions.Add(this);
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