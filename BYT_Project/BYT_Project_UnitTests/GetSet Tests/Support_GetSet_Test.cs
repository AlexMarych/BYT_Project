using BYT_Project.Model;

namespace BYT_Project_UnitTests.MultiAspect_Tests.GetSet_Tests;

public class Support_GetSet_Test
{
    private static Support support = new(5, "adad", new(), "dasda", "ada", new(), new());

    [Test]

    public void Petitions_Test()
    {
        var petitions = new List<Petition>();
        support.Petitions = petitions;
        var actualPetitions = support.Petitions;
        
        CollectionAssert.AreEqual(petitions, actualPetitions);
    }

    [Test]
    public void SlaryBonus_Test()
    {
        int expSalaryBonus = 3000;
        support.SalaryBonus = expSalaryBonus;
        var actualBonus = support.SalaryBonus;
        
        Assert.AreEqual(expSalaryBonus, actualBonus);
    }
    
}