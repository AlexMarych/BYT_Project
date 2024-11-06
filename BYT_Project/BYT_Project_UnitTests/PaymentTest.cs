using BYT_Project.Model;

namespace BYT_Project_UnitTests;

public class PaymentTest
{
    private static Student student =
        new Student("Mike", "Wazowski", new DateTime(2003, 07, 21), 
            new DateTime(2020, 08, 11), 12000, 4);
    
    static IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

    static List<Test>? questions = new List<Test>();
    
    private static Course course = new Managment("name", 20000, role, Course.DifficultyLevel.Advanced, questions);

    private Payment payment = new Payment(new DateTime(2023, 11, 11), student, course);

    [Test]
    public void PaymentDataValidation_PaymentDate()
    {
        Assert.IsInstanceOf<DateTime>(payment.PaymentDate);
    }
    
    [Test]
    public void PaymentDataValidation_StudentObject()
    {
        Assert.IsInstanceOf<Student>(payment.Student);
    }
    
    [Test]
    public void PaymentDataValidation_CourseObject()
    {
        Assert.IsInstanceOf<Course>(payment.Course);
    }
    
    
}