using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model;

[Serializable]
public class StudentTest
{
    [Required]
    public Student Student { get; set; }

    [Required]
    public Test Test { get; set; }

    [Range(2, 5)]
    public int Grade { get; set; }

    private static List<StudentTest> _extent = [];

    static StudentTest()
    {
        _extent = ExtentManager.LoadExtent<StudentTest>();
    }

    public StudentTest(Student student, Test test, int grade)
    {
        Student = student;
        Test = test;
        Grade = grade;

        CutsomValidator.Validate(this);

        _extent.Add(this);
        ExtentManager.ClearExtent<StudentTest>();
        ExtentManager.SaveExtent(_extent);
    }

    public override bool Equals(object? obj)
    {
        return obj is StudentTest test &&
               EqualityComparer<Student>.Default.Equals(Student, test.Student) &&
               EqualityComparer<Test>.Default.Equals(Test, test.Test);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Student, Test);
    }
}