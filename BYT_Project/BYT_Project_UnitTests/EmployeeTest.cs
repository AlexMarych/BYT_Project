using BYT_Project.Model;
using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project_UnitTests;


public class EmployeeTest
{
    
    Employee employee = new Support(1000, "Senior", new DateTime(2021, 06, 21), "Mike", "Wazowski",
        new DateTime(1989, 06, 11), new DateTime(2021, 06, 22));
    
    [Test]
    public void EmployeeDataValidationTest_Salary()
    {
        Assert.IsInstanceOf<int>(employee.Salary);
    }
    
    [Test]
    public void EmployeeDataValidationTest_Experience()
    {
        Assert.IsInstanceOf<string>(employee.Experience);
    }
    
    [Test]
    public void EmployeeDataValidationTest_DateOfEmployment()
    {
        Assert.IsInstanceOf<DateTime>(employee.DateOfEmployment);
    }
    
    [Test]
    public void EmployeeDataValidationTest_Name()
    {
        Assert.IsInstanceOf<string>(employee.Name);
    }
    
    [Test]
    public void EmployeeDataValidationTest_Surname()
    {
        Assert.IsInstanceOf<string>(employee.Surname);
    }
    
    [Test]
    public void EmployeeDataValidationTest_DateOfBirth()
    {
        Assert.IsInstanceOf<DateTime>(employee.DateOfBirth);
    }
    
    [Test]
    public void EmployeeDataValidationTest_CreatedTime()
    {
        Assert.IsInstanceOf<DateTime>(employee.CreatedAt);
    }
    [Test]
    public void EmployeeRangeValidationTest_Salary()
    {
        Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
            new Support(-1, "Senior", new DateTime(2021, 06, 21), "Mike", "Wazowski",
        new DateTime(1989, 06, 11), new DateTime(2021, 06, 22))));
    }

    [Test]
    public void EmployeeEmptySringValidationTest_Expirience()
    {
        Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
            new Support(1000, "", new DateTime(2021, 06, 21), "Mike", "Wazowski",
        new DateTime(1989, 06, 11), new DateTime(2021, 06, 22))));
    }
}