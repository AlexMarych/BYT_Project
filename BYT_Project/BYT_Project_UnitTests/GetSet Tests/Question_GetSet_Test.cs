using BYT_Project.Model;

namespace BYT_Project_UnitTests.MultiAspect_Tests.GetSet_Tests;

public class Question_GetSet_Test
{
    private Question question = new Question("Swofford?", "Sir yes sir!", new List<string>
            {
                "dadad",
                "dadada"
            });

    [Test]
    public void Text_Test()
    {
        string expText = "What the **** are you even doing here?";
        question.Text = expText;
        var actualText = question.Text;
        
        Assert.AreEqual(expText, actualText);
    }

    [Test]

    public void Answer_Test()
    {
        string expAnswer = "Sir, I got lost on the way to college sir!";
        question.Answer = expAnswer;
        var actualAnswer = question.Answer;
        
        Assert.AreEqual(expAnswer, actualAnswer);
    }

    [Test]
    public void ListOfAnswers_Test()
    {
        var answers = new List<string>();
        question.PossibleAnswers = answers;
        var actualAnswers = question.PossibleAnswers;
        
        CollectionAssert.AreEqual(answers, actualAnswers);
    }
    
}