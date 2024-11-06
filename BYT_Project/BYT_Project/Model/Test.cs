using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model;

[Serializable]
public class Test
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public TimeSpan SolvingTime { get; set; }

    [MaxLength(2)]
    public List<Question> Questions { get; set; } = [];

    private static List<Test> _extent = [];

    static Test()
    {
        _extent = ExtentManager.LoadExtent<Test>();
    }

    public Test(DateTime createdAt, TimeSpan solvingTime, List<Question> questions)
    {
        CreatedAt = createdAt;
        SolvingTime = solvingTime;
        Questions = questions;

        CutsomValidator.Validate(this);

        _extent.Add(this);
        ExtentManager.ClearExtent<Test>();
        ExtentManager.SaveExtent(_extent);
    }

    public override string ToString()
    {
        return $"Id: {Id}, CreatedAt: {CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}, SolvingTime: {SolvingTime}";
    }
}