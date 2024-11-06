using BYT_Project.Model;

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
        Assert.IsInstanceOf<DateTime>(test.SolvingTime);
    }
    
    [Test]
    public void TestDataValidation_QuestionsList()
    {
        Assert.IsInstanceOf<List<Question>>(test.Questions);
    }
}