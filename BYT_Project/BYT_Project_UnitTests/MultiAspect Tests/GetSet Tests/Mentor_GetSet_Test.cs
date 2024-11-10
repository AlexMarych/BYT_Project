using BYT_Project.Model;

namespace BYT_Project_UnitTests.MultiAspect_Tests.GetSet_Tests;

public class Mentor_GetSet_Test
{
    //[Test]
    //public void Specialization_Test()
    //{
    //    string expSpecialization = "specialist";
    //    var mentor = new Mentor(1000, "Senior", new DateTime(2021, 06, 21), "Mike", "Wazowski",
    //        new DateTime(1989, 06, 11), new DateTime(2021, 06, 22), expSpecialization, null);

    //    string actualSpecialization = mentor.Specialization;
    //    Assert.AreEqual(expSpecialization, actualSpecialization);
    //}

    [Test]
    public void Chief_Test()
    {
        var bossMentor = new Mentor(10000, "Super-Senior", new DateTime(2021, 06, 21), "Kirill", "Wazowski",
        new DateTime(1989, 06, 11), new DateTime(2021, 06, 22), "guru", null);

        var mentor = new Mentor(1000, "Senior", new DateTime(2021, 06, 21), "Mike", "Wazowski",
            new DateTime(1989, 06, 11), new DateTime(2021, 06, 22), "spec", bossMentor);

        mentor.Chief = bossMentor;
        var actualChief = mentor.Chief;

        Assert.AreEqual(bossMentor, actualChief);

        //надеюсь эта хуйня работает, но вроде, все должно быть по красоте: статус показывает что все ок
        //нужно будет обкатать с входными данными 
        //воооот такие дела
    }

    //[Test]
    //public void Course_Test()
    //{
    //    var courses = new List<Course>();
    //    var mentor = new Mentor(1000, "Senior", new DateTime(2021, 06, 21), "Mike", "Wazowski",
    //        new DateTime(1989, 06, 11), new DateTime(2021, 06, 22), "spec", null);

    //    mentor.Courses = courses;
    //    var actualCourses = mentor.Courses;
    //    CollectionAssert.AreEqual(courses, actualCourses);

    //}
}