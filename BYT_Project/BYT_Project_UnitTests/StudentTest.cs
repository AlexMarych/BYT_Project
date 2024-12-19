using BYT_Project.Model;
using BYT_Project.Utils.Exceptions;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;
using static BYT_Project.Model.Course;
using static BYT_Project.Model.Managment;
using System.Data;

namespace BYT_Project_UnitTests;

public class StudentTest
{
    private Student student = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21),
    new DateTime(2020, 08, 11), 1000, []);

    [Test]
    public void StudentValidationTest_Name()
    {
        Assert.IsInstanceOf<string>(student.Name);
    }

    [Test]
    public void StudentValidationTest_Surname()
    {
        Assert.IsInstanceOf<string>(student.Surname);
    }

    [Test]
    public void StudentValidationTest_DateOfBirth()
    {
        Assert.IsInstanceOf<DateTime>(student.DateOfBirth);
    }
    [Test]
    public void StudentValidationTest_CreatedAtDate()
    {
        Assert.IsInstanceOf<DateTime>(student.CreatedAt);
    }

    [Test]
    public void StudentValidationTest_Ballance()
    {
        Assert.IsInstanceOf<int>(student.Balance);
    }

    [Test]
    public void StudentValidationTest_GPA()
    {
        Assert.IsInstanceOf<int>(student.Gpa);
    }


    [Test]
    public void SupportDataValidationTest_StudentTests()
    {
        Assert.IsInstanceOf<List<BYT_Project.Model.StudentTest>>(student.StudentTests);
    }

    [Test]
    public void StudentRangeValidationTest_Balance()
    {
        Assert.Throws<ValidationException>(() => CustomValidator.Validate(
            new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21),
            new DateTime(2020, 08, 11), -1, [])));
    }

    [Test]
    public void AssignPetition()
    {
        var st = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21),
            new DateTime(2020, 08, 11), 1000, []);

        var pt = new Petition(student, "petition", Petition.StatusType.Opened);

        var before = st.Petitions.Count;
        st.AssignPetition(pt);

        var after = st.Petitions.Count;

        Assert.That(before < after);
    }

    [Test]
    public void Delete()
    {
        var st = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21),
            new DateTime(2020, 08, 11), 1000, []);

        var before = Student._extent.Count;

        Student.Delete(st);

        var after = Student._extent.Count;

        Assert.That(before > after);
    }

    [Test]
    public void CreateNotNull()
    {
        Assert.NotNull(new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21),
            new DateTime(2020, 08, 11), 1000, []));
    }

    [Test]
    public void CreateNull()
    {
        Assert.Null(Student.Create("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21), -100));
    }

    [Test]
    public void AssignPayment()
    {
        var st = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21),
        new DateTime(2020, 08, 11), 1000, []);
        var pt = new Text_Managment("field", new(), "ss", Level.Top, "middle", 12, new Dictionary<string, Mentor>(), DifficultyLevel.Advanced, new());

        var before = st.Payments.Count;
        st.AddPayment(pt);

        var after = st.Payments.Count;

        Assert.That(before < after);
    }

    [Test]
    public void AddStudentTest()
    {
        var st = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21),
new DateTime(2020, 08, 11), 1000, []);
        var pt = new Test(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), new()
        {
            new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"}),
            new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"}),
            new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"})
        });

        var before = st.StudentTests.Count;
        st.AddStudentTest(pt, 5);

        var after = st.StudentTests.Count;

        Assert.That(before < after);
    }
}