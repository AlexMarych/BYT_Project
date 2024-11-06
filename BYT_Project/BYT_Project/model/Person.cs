using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    [Serializable]
    public abstract class Person
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }

        protected Person(string name, string surname, DateTime dateOfBirth, DateTime createdAt)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            CreatedAt = createdAt;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Surname: {Surname}, DateOfBirth: {DateOfBirth.ToString("yyyy-MM-dd")}, CreatedAt: {CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}";
        }
    }
}