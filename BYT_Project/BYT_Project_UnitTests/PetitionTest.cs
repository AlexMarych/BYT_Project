using BYT_Project.Model;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project_UnitTests
{
    internal class PetitionTest
    {
        Petition petition = new Petition("petition", Petition.StatusType.Opened);

        [Test]
        public void PetitionDataValidationTest_Text()
        {
            Assert.IsInstanceOf<string>(petition.Text);
        }
        [Test]
        public void PetitionDataValidationTest_Status()
        {
            Assert.IsInstanceOf<Enum>(petition.Status);
        }
        [Test]
        public void PetitionEmptySringValidationTest_Text()
        {
            Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
                new Petition("", Petition.StatusType.Opened)));
        }
    }
}
