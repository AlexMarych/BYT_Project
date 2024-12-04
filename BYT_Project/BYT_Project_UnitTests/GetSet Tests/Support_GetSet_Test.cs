using BYT_Project.Model;

namespace BYT_Project_UnitTests.GetSet_Tests;

public class Support_GetSet_Test
{
    private static Support support = new(5, "adad", new(), "da", "dada", "dog@gmail.com", new(), new(), []);

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
        var actualBonus = support.SalaryBonus;
        
        Assert.AreEqual(0, actualBonus);
    }
    
}