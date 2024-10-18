namespace BYT_Project.model
{
    public abstract class Person
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}