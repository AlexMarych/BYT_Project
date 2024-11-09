using BYT_Project.Model;

namespace BYT_Project_UnitTests;

public class StudentTestClassTest
{
    private static Student student = new("Mike", "Wazowski", new DateTime(2003, 07, 21), new DateTime(2020, 08, 11), 12000, 4);
    private static Test test = new(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), []);
    private static BYT_Project.Model.StudentTest studentTest = new(student, test, 5);

    [Test]
    public void StudentTestDataValidationTest_Student()
    {
        Assert.IsInstanceOf<Student>(studentTest.Student);
    }

    [Test]
    public void StudentTestDataValidationTest_Test()
    {
        Assert.IsInstanceOf<Test>(studentTest.Test);
    }

    [Test]
    public void StudentTestDataValidationTest_Grade()
    {
        Assert.IsInstanceOf<int>(studentTest.Grade);
    }
}