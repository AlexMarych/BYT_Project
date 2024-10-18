namespace BYT_Project.Model;

public class Test
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public TimeSpan SolvingTime { get; set; }
    
    public List<Question> Questions { get; set; }

    public Test()
    {
        Questions = [];
    }
}