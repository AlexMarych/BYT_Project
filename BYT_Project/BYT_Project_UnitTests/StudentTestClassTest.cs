using BYT_Project.Model;
using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project_UnitTests;

public class StudentTestClassTest
{
    private static Student student =
        new Student("Mike", "Wazowski", new DateTime(2003, 07, 21),
            new DateTime(2020, 08, 11), 12000, 4);
    private static List<Question> questions = new List<Question>();
    private static Test test = new Test(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), questions);

    private BYT_Project.Model.StudentTest studentTest = new BYT_Project.Model.StudentTest(student, test,4);

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

    [Test]
    public void StudentRangeValidationTest_Grade()
    {
        Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
             new BYT_Project.Model.StudentTest(student, test, 6)));
    }

    [Test]
    public void StudentRequiredValidationTest_Student()
    {
        Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
            new BYT_Project.Model.StudentTest(null, test, 3)));
    }
    [Test]
    public void StudentRequiredValidationTest_Test()
    {
        Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
            new BYT_Project.Model.StudentTest(student, null, 3)));
    }
}