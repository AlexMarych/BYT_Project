using BYT_Project.Model;
using System.ComponentModel.DataAnnotations;
using BYT_Project.Utils.Validation;

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

    [Test]
    public void QuestionEmptySringValidationTest_Text()
    {
        Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
            new Question("", "Sir yes sir!", new List<string>())));
    }

    [Test]
    public void QuestionEmptySringValidationTest_Answer()
    {
        Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
            new Question("Swofford?", "", new List<string>())));
    }
}