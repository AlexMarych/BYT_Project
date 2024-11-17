using BYT_Project.Model;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

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
    public void StudentRangeValidationTest_Gpa()
    {
        Student stud = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21),
            new DateTime(2020, 08, 11), 6, []);
        Assert.Throws<ValidationException>(() => CustomValidator.Validate(stud));
    }


}