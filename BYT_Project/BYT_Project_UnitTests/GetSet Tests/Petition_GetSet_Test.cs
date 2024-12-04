using BYT_Project.Model;

namespace BYT_Project_UnitTests.GetSet_Tests;

public class Petition_GetSet_Test
{
    static Petition petition = new Petition("Sample Petition", Petition.StatusType.Opened);

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