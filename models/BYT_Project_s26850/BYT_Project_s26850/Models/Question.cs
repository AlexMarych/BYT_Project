namespace BYT_Project_s26850.Models;

public class Question
{
    public long id { get; set; }
    public string text { get; set; }
    public string answer { get; set;  }
    public List<string> possibleAnsers { get; set; }

    public Question()
    {
        possibleAnsers = new List<string>();
    }
    
}