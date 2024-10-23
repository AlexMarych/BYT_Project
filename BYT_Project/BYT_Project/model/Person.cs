namespace BYT_Project.Model
{
    public abstract class Person
    {
        public long Id { get; set; }
        public  string Name { get; set; }
        public  string Surname { get; set; }
        public  DateTime DateOfBirth { get; set; }
        public  DateTime CreatedAt { get; set; }

        protected Person( string name, string surname, DateTime dateOfBirth, DateTime createdAt)
        {
            
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            CreatedAt = createdAt;
        }
    }
}