using BYT_Project.Model;

namespace BYT_Project_UnitTests.GetSet_Tests;

public class Petition_GetSet_Test
{
    static Student student = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21), new DateTime(2020, 08, 11), 1000, []);
    static Petition petition = new Petition(student,"Sample Petition", Petition.StatusType.Opened);

    [Test]
    public void Text_Test()
    {
        string expText = "Some new text ";
        petition.Text = expText;
        var actualText = petition.Text;
        
        Assert.AreEqual(expText, actualText);
    }

    [Test]

    public void Status_Test()
    {
        petition.Status = Petition.StatusType.Closed;
        var actualStatus = petition.Status;
        
        Assert.AreEqual(Petition.StatusType.Closed, actualStatus);
    }
    
    
}