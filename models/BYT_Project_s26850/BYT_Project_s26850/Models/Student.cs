namespace BYT_Project_s26850.Models;

public class Student : Person
{
    public int Balance { get; set; }
    public int Gpa { get; set; }
    
    public List<StudentTest> StudentTests { get; set; }
    public List<Payment> Payments { get; set; }
    
    public Student()
    {
        StudentTests = new List<StudentTest>();
        Payments = new List<Payment>();
    }
}