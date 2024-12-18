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

        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        private static int _staticId;

        protected Person(string name, string surname, string email, DateTime dateOfBirth, DateTime createdAt)
        {
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
            CreatedAt = createdAt;

            Id = ++_staticId;
        }


        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Surname: {Surname}, DateOfBirth: {DateOfBirth.ToString("yyyy-MM-dd")}, CreatedAt: {CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   Id == person.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}