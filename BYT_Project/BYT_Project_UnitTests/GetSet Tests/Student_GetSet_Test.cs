using System.ComponentModel.DataAnnotations;
using BYT_Project.Model;

namespace BYT_Project_UnitTests.MultiAspect_Tests.GetSet_Tests;

public class Student_GetSet_Test
{
    
    [Test]
    public void Balance_Test()
    {
        int expBalance = 1000;
        var student = new Student("Mike", "Wazowski", new DateTime(2003, 07, 21),
            new DateTime(2020, 08, 11), expBalance, 4);

        int actualBalance = student.Balance;
        
        Assert.AreEqual(expBalance, actualBalance);
    }

    [Test]
    public void GPA_Test()
    {
        int expGPA = 2;
        var student = new Student("Mike", "Wazowski", new DateTime(2003, 07, 21),
            new DateTime(2020, 08, 11), 1000, expGPA);

        int actualGPA = student.Gpa;
        
        Assert.AreEqual(expGPA, actualGPA);
    }

    [Test]
    public void Petitions_Test()
    {
        var petitons = new List<Petition>();
        var student = new Student("Mike", "Wazowski", new DateTime(2003, 07, 21),
            new DateTime(2020, 08, 11), 1000, 4);

        student.Petitions = petitons;
        var actualPetitions = student.Petitions;
        CollectionAssert.AreEqual(petitons, actualPetitions);
    }

    [Test]
    public void Course_Test()
    {

        var courses = new List<Course>();
        var student = new Student("Mike", "Wazowski", new DateTime(2003, 07, 21),
            new DateTime(2020, 08, 11), 1000, 4);

        student.Courses = courses;
        var actualCourses = student.Courses;
        CollectionAssert.AreEqual(courses, actualCourses);
    }
    

}