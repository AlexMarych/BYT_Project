namespace BYT_Project.Model;

public class Question
{
    public long Id { get; set; }
    public string Text { get; set; }
    public string Answer { get; set;  }
    public List<string> PossibleAnswers { get; set; }

    private static List<Question> _extent = [];

    public Question()
    {
        PossibleAnswers = [];

        _extent.Add(this);

        ExtentManager.SaveExtent(_extent);
    }
    
}