using BYT_Project.Utils;

namespace BYT_Project.Model;

[Serializable]
public class Test
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public TimeSpan SolvingTime { get; set; }

    public List<Question> Questions { get; set; } = [];

    private static List<Test> _extent = [];

    public Test(DateTime createdAt, TimeSpan solvingTime, List<Question> questions)
    {
        CreatedAt = createdAt;
        SolvingTime = solvingTime;
        Questions = questions;

        CutsomValidator.Validate(this);

        _extent.Add(this);
    }

    public override string ToString()
    {
        return $"Id: {Id}, CreatedAt: {CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}, SolvingTime: {SolvingTime}";
    }
}