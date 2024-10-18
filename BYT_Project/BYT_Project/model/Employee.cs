namespace BYT_Project.model
{
    public class Employee : Person
    {
        public int Salary { get; set; }
        public required string Experience { get; set; }
        public required DateTime DateOfEmployment { get; set; }
    }
}