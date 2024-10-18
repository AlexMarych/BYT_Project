namespace BYT_Project_s26850.Models;

public class Question
{
    public long Id { get; set; }
    public string Text { get; set; }
    public string Answer { get; set;  }
    public List<string> PossibleAnswers { get; set; }

    public Question()
    {
        PossibleAnswers = new List<string>();
    }
    
}