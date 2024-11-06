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

    public StudentTest(Student student, Test test, int grade)
    {
        Student = student;
        Test = test;
        Grade = grade;

        CutsomValidator.Validate(this);

        _extent.Add(this);
    }
}