namespace BYT_Project.Model;

public class StudentTest
{
    public required Student Student { get; set; }
    public required Test Test { get; set; }
    public int Grade { get; set; }

    private static List<StudentTest> _extent = [];
    public StudentTest(Student student, Test test, int grade)
    {
        Student = student;
        Test = test;
        Grade = grade;

        _extent.Add(this);

        ExtentManager.SaveExtent(_extent);
    }
}