using BYT_Project.Model;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project_UnitTests
{
    internal class PetitionTest
    {
        static Student student = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21), new DateTime(2020, 08, 11), 1000, []);
        Petition petition = new Petition(student,"petition", Petition.StatusType.Opened);

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
            Assert.Throws<ValidationException>(() => CustomValidator.Validate(
                new Petition(student,"", Petition.StatusType.Opened)));
        }
    }
}
