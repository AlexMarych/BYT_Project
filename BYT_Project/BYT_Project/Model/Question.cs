using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model;

public class Question
{
    public long Id { get; set; }
    [Required(AllowEmptyStrings = false)]
    public string Text { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string Answer { get; set;  }
    public List<string>? PossibleAnswers { get; set; }

    private static List<Question> _extent = [];

    public Question(long id, string text, string answer, List<string>? possibleAnswers)
    {
        Id = id;
        Text = text;
        Answer = answer;
        PossibleAnswers = possibleAnswers;

        _extent.Add(this);

        ExtentManager.SaveExtent(_extent);
    }
}