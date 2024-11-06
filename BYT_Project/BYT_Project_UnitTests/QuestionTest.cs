using BYT_Project.Model;

namespace BYT_Project_UnitTests;

public class QuestionTest
{
    private Question question = new Question("Swofford?", "Sir yes sir!", new List<string>());


    [Test]
    public void QuestionDataValidation_QuestionText()
    {
        Assert.IsInstanceOf<string>(question.Text);
    }
    
    [Test]
    public void QuestionDataValidation_QuestionAnswer()
    {
        Assert.IsInstanceOf<string>(question.Answer);
    }
    
    [Test]
    public void QuestionDataValidation_PossibleAnswers()
    {
        Assert.IsInstanceOf<List<string>>(question.PossibleAnswers);
    }
}