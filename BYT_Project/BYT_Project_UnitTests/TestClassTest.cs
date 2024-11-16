using BYT_Project.Model;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project_UnitTests;

public class TestClassTest
{
    private static List<Question> questions = new List<Question>();
    Test test = new Test( new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), questions);

    [Test]
    public void TestDataValidation_CreatedAt()
    {
        Assert.IsInstanceOf<DateTime>(test.CreatedAt);
    }
    
    [Test]
    public void TestDataValidation_SolvingTime()
    {
        Assert.IsInstanceOf<TimeSpan>(test.SolvingTime);
    }
    
    [Test]
    public void TestDataValidation_QuestionsList()
    {
        Assert.IsInstanceOf<List<Question>>(test.Questions);
    }

    [Test]
    public void TestLenthValidation_Questions()
    {
        Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
            new Test(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), new List<Question>() {
            null,
            null,
            null
                })));
    }
}