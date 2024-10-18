namespace BYT_Project_s26850.Models;

public class Test
{
    public long id { get; set; }
    public DateTime createdAt { get; set; }
    public TimeSpan solvingTime { get; set; }
    
    public List<Question> Questions { get; set; }

    public Test()
    {
        Questions = new List<Question>();
    }
}