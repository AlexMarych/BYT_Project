using BYT_Project.Model;

namespace BYT_Project_UnitTests.GetSet_Tests;

public class Mentor_GetSet_Test
{
    private static Mentor mentor = new Mentor(1000, "Senior", new DateTime(2021, 06, 21), "Mike", "Wazowski", "dog@gmail.com",
        new DateTime(1989, 06, 11), new DateTime(2021, 06, 22), "spec", null);
    [Test]
    public void Specialization_Test()
    {
        string actualSpecialization = mentor.Specialization;
        Assert.AreEqual("spec", actualSpecialization);
    }

    [Test]
    public void Chief_Test()
    {
        var bossMentor = new Mentor(10000, "Super-Senior", new DateTime(2021, 06, 21), "Kirill", "Wazowski", "dog@gmail.com",
        new DateTime(1989, 06, 11), new DateTime(2021, 06, 22), "guru", null);

        mentor.Chief = bossMentor;
        var actualChief = mentor.Chief;

        Assert.AreEqual(bossMentor, actualChief);
    }

    [Test]
    public void Course_Test()
    {
        var courses = new List<Course>();

        mentor.Courses = courses;
        var actualCourses = mentor.Courses;
        CollectionAssert.AreEqual(courses, actualCourses);
    }
}