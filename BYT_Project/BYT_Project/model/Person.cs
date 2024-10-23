using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public abstract class Person
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        private static List<Person> _extent = [];

        protected Person(string name, string surname, DateTime dateOfBirth, DateTime createdAt)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            CreatedAt = createdAt;

            _extent.Add(this);
            ExtentManager.SaveExtent(_extent);
        }
    }
}