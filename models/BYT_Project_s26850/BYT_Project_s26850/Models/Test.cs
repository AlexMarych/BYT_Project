namespace BYT_Project_s26850.Models;

public class Test
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public TimeSpan SolvingTime { get; set; }
    
    public List<Question> Questions { get; set; }

    public Test()
    {
        Questions = new List<Question>();
    }
}