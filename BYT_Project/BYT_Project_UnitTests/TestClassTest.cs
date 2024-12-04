using BYT_Project.Model;
using BYT_Project.Utils;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project_UnitTests;

public class TestClassTest
{
    private static List<Question> questions = new()
    {
        new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"}),
        new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"}),
        new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"})
    };
    Test test = new Test(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), questions);

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
        Assert.Throws<ValidationException>(() => CustomValidator.Validate(
            new Test(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), new List<Question>() {
            null})));
    }

    [Test]
    public void CreateValidTest_Test()
    {
        Assert.NotNull(Test.Create(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), new()
        {
            new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"}),
            new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"}),
            new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"})
        }));
    }

    [Test]
    public void CreateInvalidTest_Test()
    {
        Assert.Null(Test.Create(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), new()
        {
            new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"})
        }));
    }

    [Test]
    public void TestAssociation_TestQuestions()
    {
        List<Question> questions =
        [
            new("Swofford?", "Sir yes sir!", ["ewew", "dadad"]),
            new("Swofford?", "Sir yes sir!", ["ewew", "dadad"]),
            new("Swofford?", "Sir yes sir!", ["ewew", "dadad"])
        ];

        Test? test = Test.Create(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), questions);

        var testList = Test._extent;
        var questionList = Test._extent;

        var testBeforeCount = testList.Count;
        var questionBeforeCount = questionList.Count;

        Test.Delete(test);

        var testAfterCount = testList.Count;
        var questionAfterCount = questionList.Count;

        Assert.That(testBeforeCount > testAfterCount && questionBeforeCount > questionAfterCount);
    }
}