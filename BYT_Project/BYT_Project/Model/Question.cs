using BYT_Project.Utils;
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
    public List<string> PossibleAnswers { get; set; }

    private static List<Question> _extent = [];

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
        ExtentManager.ClearExtent<Question>();
        ExtentManager.SaveExtent(_extent);
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