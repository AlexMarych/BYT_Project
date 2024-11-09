using BYT_Project.Model;
using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project_UnitTests;

public class StudentTest
{
    private Student student =
        new Student("Mike", "Wazowski", new DateTime(2003, 07, 21), 
            new DateTime(2020, 08, 11), 12000, 4);

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
    public void StudentRangeValidationTest_Balance()
    {
        Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
            new Student("Mike", "Wazowski", new DateTime(2003, 07, 21),
            new DateTime(2020, 08, 11), -1, 4)));
    }

    [Test]
    public void StudentRangeValidationTest_Gpa()
    {
        Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
            new Student("Mike", "Wazowski", new DateTime(2003, 07, 21),
            new DateTime(2020, 08, 11), 12000, 6)));
    }
}