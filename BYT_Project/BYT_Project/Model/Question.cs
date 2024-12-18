using BYT_Project.Utils;
using BYT_Project.Utils.Exceptions;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model;

[Serializable]
public class Question
{
    public long Id { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Text { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Answer { get; set; }

    [NoEmptyStrings]
    [MinLength(2)]
    public List<string> PossibleAnswers { get; set; }

    public Test Test { get; set; }

    public static List<Question> _extent { get; } = [];
    private static int _staticId;

    static Question()
    {
        _extent = ExtentManager.LoadExtent<Question>();
    }

    public Question(string text, string answer, List<string> possibleAnswers)
    {
        Text = text;
        Answer = answer;
        PossibleAnswers = possibleAnswers;

        CustomValidator.Validate(this);

        _extent.Add(this);

        Id = ++_staticId;
        ExtentManager.ClearExtent<Question>();
        ExtentManager.SaveExtent(_extent);
    }

    public static Question? Create(string text, string answer, List<string> possibleAnswers)
    {
        try
        {
            return new Question(text, answer, possibleAnswers);
        }
        catch (ValidationException)
        {
            return null;
        }
    }

    public static void Modifiy(Question question)
    {

        Question modifiyable = _extent.First(x => x.Id == question.Id);

        _extent.Remove(modifiyable);
        _extent.Add(question);

        ExtentManager.ClearExtent<Question>();
        ExtentManager.SaveExtent(_extent);
    }

    public static void Delete(List<Question> questions)
    {
        questions.ForEach(x => _extent.Remove(x));
        ExtentManager.ClearExtent<Question>();
        ExtentManager.SaveExtent(_extent);
    }

    public bool AddTest(Test test)
    {
        Test = test;

        if (test.Questions.Contains(this))
            return false;

        test.AddQuestion(this);
        ExtentManager.ClearExtent<Question>();
        ExtentManager.SaveExtent(_extent);

        return true;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Text: {Text}, Answer: {Answer}, PossibleAnswers: {PossibleAnswers}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Question question &&
               Id == question.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}