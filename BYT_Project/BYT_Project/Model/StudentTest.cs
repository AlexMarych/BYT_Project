namespace BYT_Project.Model;

[Serializable]
public class StudentTest
{
    public Student Student { get; set; }
    public Test Test { get; set; }
    public int Grade { get; set; }

    private static List<StudentTest> _extent = [];

    public StudentTest(Student student, Test test, int grade)
    {
        Student = student;
        Test = test;
        Grade = grade;

        _extent.Add(this);
    }
}