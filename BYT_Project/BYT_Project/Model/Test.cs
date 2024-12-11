using BYT_Project.Utils;
using BYT_Project.Utils.Exceptions;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model;

[Serializable]
public class Test
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public TimeSpan SolvingTime { get; set; }

    [MinLength(2)]
    public List<Question> Questions { get; set; } = [];

    public static List<Test> _extent { get; } = [];

    static Test()
    {
        _extent = ExtentManager.LoadExtent<Test>();
    }

    public Test(DateTime createdAt, TimeSpan solvingTime, List<Question> questions)
    {
        CreatedAt = createdAt;
        SolvingTime = solvingTime;
        Questions = questions;

        CustomValidator.Validate(this);

        _extent.Add(this);
        ExtentManager.ClearExtent<Test>();
        ExtentManager.SaveExtent(_extent);
    }

    public static Test? Create(DateTime createdAt, TimeSpan solvingTime, List<Question> questions)
    {
        try
        {
            return new Test(createdAt, solvingTime, questions);
        }
        catch (ValidationException)
        {
            return null;
        }
    }

    public static void Delete(Test test)
    {
        Question.Delete(test.Questions);
        _extent.Remove(test);
        ExtentManager.ClearExtent<Test>();
        ExtentManager.SaveExtent(_extent);
    }

    public void AddQuestion(Question question)
    {
        try
        {
            if (this.Questions.Contains(question)) throw new ReverseConnectionException();
            Questions.Add(question);
            question.AddTest(this);
        } catch (ReverseConnectionException e) { }
    }

    public override string ToString()
    {
        return $"Id: {Id}, CreatedAt: {CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}, SolvingTime: {SolvingTime}";
    }

    public override bool Equals(object? obj)
    {
        return obj is Test test &&
               Id == test.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}