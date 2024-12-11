using BYT_Project.Model;
using System.ComponentModel.DataAnnotations;
using BYT_Project.Utils.Validation;

namespace BYT_Project_UnitTests;

public class QuestionTest
{
    private Question question = new Question("Swofford?", "Sir yes sir!", new List<string>
            {
                "dadad",
                "dadada"
            });

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
        Assert.Throws<ValidationException>(() => CustomValidator.Validate(
            new Question("", "Sir yes sir!", new List<string>())));
    }

    [Test]
    public void QuestionEmptySringValidationTest_Answer()
    {
        Assert.Throws<ValidationException>(() => CustomValidator.Validate(
            new Question("Swofford?", "", new List<string>())));
    }

    [Test]
    public void QuestionEmptySringValidationTest_PossibleAnswers()
    {
        Assert.Throws<ValidationException>(() => CustomValidator.Validate(
            new Question("Swofford?", "Sir Yes Sir", ["",""] )));
    }

    [Test]
    public void QuestionAmountValidationTest_PossibleAnswers()
    {
        Assert.Throws<ValidationException>(() => CustomValidator.Validate(
            new Question("Swofford?", "Sir Yes Sir", ["aaaaaa"])));
    }
    
    [Test]
    public void CreateQuestionValidTest()
    {
        Assert.NotNull(Question.Create("bubub", "bubu_correct", new List<string>
        {
            "bubububu?",
            "bubububububububu?"
        }));
    }
        
    [Test]
    public void CreateQuestionInvalidTest()
    {
        Assert.Null(Question.Create(null, null, []));
    }
    
    
}