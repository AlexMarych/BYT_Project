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
    public List<string> PossibleAnswers { get; set; }

    private static List<Question> _extent = [];

    public Question(string text, string answer, List<string>? possibleAnswers)
    {
        Text = text;
        Answer = answer;
        PossibleAnswers = possibleAnswers;

        _extent.Add(this);
    }

    public override string ToString()
    {
        return $"Id: {Id}, Text: {Text}, Answer: {Answer}, PossibleAnswers: {PossibleAnswers}";
    }
}