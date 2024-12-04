using BYT_Project.Model;

namespace BYT_Project_UnitTests.GetSet_Tests;

public class Payment_GetSet_Test
{
    private static Student student = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21),
        new DateTime(2020, 08, 11), 1000, []);

    private static IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

    private static List<Test>? tests = new List<Test>();

    private static Managment.Level level;
    private static Course.DifficultyLevel difficultyLevel;

    private static Course course = new Text_Managment("field", new(), "ss", level, "middle", 12, role, difficultyLevel, tests);
    

    [Test]
    public void PaymentDate_Test()
    {
        var expPaymentDate = DateTime.Now;
        var payment = new Payment(expPaymentDate, student, course);

        var actualPayment = payment.PaymentDate;
        Assert.AreEqual(expPaymentDate, actualPayment);
        
    }

    [Test]
    public void Student_Test()
    {
        var payment = new Payment(DateTime.Now, student, course);
        var actualStudent = payment.Student;
        
        Assert.AreEqual(student, actualStudent);

    }

    [Test]
    public void Course_Test()
    {
        var payment = new Payment(DateTime.Now, student, course);
        var actualCourse = payment.Course;
        
        Assert.AreEqual(course, actualCourse);
    }
}