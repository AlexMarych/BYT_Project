using BYT_Project.Model;
using BYT_Project.Utils.Exceptions;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project_UnitTests
{
    internal class PetitionTest
    {
        static Student student = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21), new DateTime(2020, 08, 11), 1000, []);
        Petition petition = new Petition(student, "petition", Petition.StatusType.Opened);
        static Support support = new Support(5, "adad", new(), "da", "dada", "dog@gmail.com", new(), new(), []);

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
                new Petition(student, "", Petition.StatusType.Opened)));
        }

        [Test]
        public void CreatePetitionValidTest()
        {
            Assert.NotNull(Petition.Create(student, "bubu", Petition.StatusType.Opened));
        }

        [Test]
        public void CreatePetitionInvalidTest()
        {
            Assert.Null(Petition.Create(null, null, Petition.StatusType.Opened));
        }

        [Test]

        public void ModifyPetitionTest()
        {
            Petition? testPetition = Petition.Create(student, "petition", Petition.StatusType.Opened);
            var before = Petition._extent.Count();
            Petition? changer = Petition.Create(student, "petition", Petition.StatusType.Opened);
            changer.Id = testPetition.Id;

            Petition.Modify(changer);

            var after = Petition._extent.Count();
            Assert.That(after == before);
        }

        [Test]
        public void AddStudentTest()
        {
            petition.AddStudent(student);
            Assert.That(petition.Student, Is.EqualTo(student));
        }

        [Test]
        public void AddSupportTest()
        {
            petition.AddSupport(support);
            Assert.That(petition.Support, Is.EqualTo(support));
        }

        [Test]
        public void DeletePetitionTest()
        {
            Petition? testPetition = new Petition(student, "petition", Petition.StatusType.Opened);
            var before = Petition._extent.Count;
            Petition.Delete(testPetition);
            var after = Petition._extent.Count;
            Assert.That(after == before - 1);
        }
    }
}
