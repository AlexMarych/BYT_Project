using BYT_Project.Utils;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model;

[Serializable]
public class StudentTest
{
    public int Id { get; set; }

    [Required]
    public Student Student { get; set; }

    [Required]
    public Test Test { get; set; }

    [Range(2, 5)]
    public int Grade { get; set; }

    private static List<StudentTest> _extent = [];
    private static int _staticId;
    static StudentTest()
    {
        _extent = ExtentManager.LoadExtent<StudentTest>();
    }

    public StudentTest(Student student, Test test, int grade)
    {
        Student = student;
        Test = test;
        Grade = grade;

        CustomValidator.Validate(this);

        _extent.Add(this);

        Id = ++_staticId;
        ExtentManager.ClearExtent<StudentTest>();
        ExtentManager.SaveExtent(_extent);
    }

    public static StudentTest? Create(Student student, Test test, int grade) 
    {
        try
        {
            return new StudentTest(student, test , grade);
        }
        catch 
        {
            return null;
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is StudentTest test &&
               Id == test.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}