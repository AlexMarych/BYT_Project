namespace BYT_Project_s26850.Models;

public class Student : Person
{
    public int balance { get; set; }
    public int gpa { get; set; }
    
    public List<StudentTest> StudentTests { get; set; }
    public List<Payment> Payments { get; set; }
    
    public Student()
    {
        StudentTests = new List<StudentTest>();
        Payments = new List<Payment>();
    }
}