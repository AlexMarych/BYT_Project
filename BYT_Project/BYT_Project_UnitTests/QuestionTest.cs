using BYT_Project.Model;
using System.ComponentModel.DataAnnotations;
using BYT_Project.Utils.Validation;

namespace BYT_Project_UnitTests;

public class QuestionTest
{

    //something went wrong, needed to be fixed
    private Question question = new Question("Swofford?", "Sir yes sir!", new List<string>
            {
                "dadad",
                "dadada"
            });
    private Test test = new Test(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), new List<Question> {
        new("Swofford?", "Sir yes sir!",
            [
                "dadad",
                "dadada"
            ]),
                new("Swofford?", "Sir yes sir!",
            [
                "dadad",
                "dadada"
            ]),
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
            new Question("Swofford?", "Sir Yes Sir", ["", ""])));
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

    [Test]
    public void ModifyQuestionTest()
    {
        Question? testQuestions = Question.Create("Swofford?", "Sir yes sir!", new List<string>
        {
            "dadad",
            "dadada"
        });

        var before = Question._extent.Count();

        Question? changer = Question.Create("Swofford?", "Sir yes sir!", new List<string>
        {
            "dadad",
            "dadada"
        });
        changer.Id = testQuestions.Id;

        Question.Modify(changer);
        var after = Question._extent.Count();

        Assert.That(after == before);
    }

    [Test]
    public void DeleteQuestionTest()
    {
        Question? testQuestions = Question.Create("Swofford?", "Sir yes sir!", new List<string>
        {
            "dadad",
            "dadada"
        });

        var before = Question._extent.Count();
        Question.Delete(new List<Question> { testQuestions });
        var after = Question._extent.Count();

        Assert.That(after == before - 1);
    }

    [Test]
    public void AddTest_Test()
    {
        question.AddTest(test);
        Assert.That(question.Test, Is.EqualTo(test));
    }


}