namespace BYT_Project.Model
{
    public class Employee : Person
    {
        public int Salary { get; set; }
        public required string Experience { get; set; }
        public required DateTime DateOfEmployment { get; set; }
    }
}