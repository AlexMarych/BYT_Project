using BYT_Project.Model;

namespace BYT_Project_UnitTests.GetSet_Tests;

public class Student_GetSet_Test
{
    private static Student student = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21),
    new DateTime(2020, 08, 11), 1000, []);

    [Test]
    public void Balance_Test()
    {
        int actualBalance = student.Balance;

        Assert.AreEqual(1000, actualBalance);
    }

    [Test]
    public void Email_Test()
    {
        string actualEmail = student.Email;

        Assert.AreEqual("dog@gmail.com", actualEmail);
    }

    [Test]
    public void GPA_Test()
    {
        int actualGPA = student.Gpa;

        Assert.AreEqual(0, actualGPA);
    }

    [Test]
    public void Petitions_Test()
    {
        var petitons = new List<Petition>();

        student.Petitions = petitons;
        var actualPetitions = student.Petitions;
        CollectionAssert.AreEqual(petitons, actualPetitions);
    }

    [Test]
    public void StudentTest_Test()
    {
        var studentTests = new List<BYT_Project.Model.StudentTest>();

        student.StudentTests = studentTests;
        var actualStudentTests = student.StudentTests;
    }
}