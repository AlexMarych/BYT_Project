using BYT_Project.Model;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;
namespace BYT_Project_UnitTests;

public class PaymentTest
{
    private static Student student = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21),
    new DateTime(2020, 08, 11), 1000, []);

    private static IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();
    private static Managment.Level level = Managment.Level.Top;
    private static Course.DifficultyLevel difficultyLevel = Course.DifficultyLevel.Intermidiate;
    private static Course course = new Text_Managment("field", new(), "ss", level, "middle", 12, role, difficultyLevel, []);
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

    [Test]
    public void PaymentRequiredValidationTest_Student()
    {
        Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
            new Payment(new DateTime(2023, 11, 11), null, course)));
    }

    [Test]
    public void PaymentRequiredValidationTest_Course()
    {
        Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
            new Payment(new DateTime(2023, 11, 11), student, null)));
    }
}