using BYT_Project.Model;

namespace BYT_Project_UnitTests.GetSet_Tests;

public class Test_GetSet_Test
{
    static List<Question> questions = new()
    {
        new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"}),
        new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"}),
        new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"})
    };
    static Test test = new Test( new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), questions);

    [Test]
    public void CreatedAt_Test()
    {
        var expCreatedAt = new DateTime(2023, 09, 11);
        var actualCreatedAt = test.CreatedAt;
        
        Assert.AreEqual(expCreatedAt, actualCreatedAt);
    }

    [Test]

    public void SolvingTime_Test()
    {
        var expSolvingTime = new TimeSpan(1, 30, 0);
        var actualSolvingTime = test.SolvingTime;
        
        Assert.AreEqual(expSolvingTime, actualSolvingTime);
    }

    [Test]
    public void Questions_Test()
    {
        var actualQuestions = test.Questions;
        CollectionAssert.AreEqual(questions, actualQuestions);
    }
    
    
    
}