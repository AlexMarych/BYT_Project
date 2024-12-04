using BYT_Project.Model;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;
using BYT_Project.Utils.Exceptions;

namespace BYT_Project_UnitTests
{
    internal class MentorTest
    {
        Mentor mentor = new Mentor(1000, "Senior", new DateTime(2021, 06, 21), "Mike", "Wazowski", "dog@gmail.com",
        new DateTime(1989, 06, 11), new DateTime(2021, 06, 22), "spec", null);

        [Test]
        public void MentorDataValidationTest_Salary()
        {
            Assert.IsInstanceOf<int>(mentor.Salary);
        }
        
        [Test]
        public void MentorDataValidationTest_Experience()
        {
            Assert.IsInstanceOf<string>(mentor.Experience);
        }
        
        [Test]
        public void MentorDataValidationTest_DateOfEmp()
        {
            Assert.IsInstanceOf<DateTime>(mentor.DateOfEmployment);
        }
        
        [Test]
        public void MentorDataValidationTest_Name()
        {
            Assert.IsInstanceOf<string>(mentor.Name);
        }
        
        [Test]
        public void MentorDataValidationTest_Surname()
        {
            Assert.IsInstanceOf<string>(mentor.Surname);
        }

        [Test]
        public void MentorDataValidationTest_Email()
        {
            Assert.IsInstanceOf<string>(mentor.Email);
        }

        [Test]
        public void MentorDataValidationTest_DateOfBirth()
        {
            Assert.IsInstanceOf<DateTime>(mentor.DateOfBirth);
        }
        
        [Test]
        public void MentorDataValidationTest_CreatedAt()
        {
            Assert.IsInstanceOf<DateTime>(mentor.CreatedAt);
        }
        
        [Test]
        public void MentorDataValidationTest_Specialization()
        {
            Assert.IsInstanceOf<string>(mentor.Specialization);
        }

        [Test]
        public void MentorEmptySringValidationTest_Specialization()
        {
            Assert.Throws<ValidationException>(() => CustomValidator.Validate(
                new Mentor(1000, "Senior", new DateTime(2021, 06, 21), "Mike", "Wazowski", "dog@gmail.com",
        new DateTime(1989, 06, 11), new DateTime(2021, 06, 22), "", null)));
        }

        [Test]
        public void MentorRecursiveCiefValidationTest()
        {
            Assert.Throws<RecursiveChiefException>(() => mentor.AssignChief(mentor));
        }

        [Test]
        public void MentorRelationValidationTest_SetChief()
        {
            Mentor Chief = new Mentor(10000, "Senior", new DateTime(2021, 06, 21), "Mikee", "Wazowskiy", "doga@gmail.com",
            new DateTime(1989, 06, 11), new DateTime(2021, 06, 22), "spect", null);

            mentor.AssignChief(Chief);
            Assert.That(mentor.Chief, Is.EqualTo(Chief));
        }

        [Test]
        public void CreateValidMentorTest()
        {
            Assert.NotNull(Mentor.Create(10000, "Senior", new DateTime(2021, 06, 21), "Mikee", "Wazowskiy", "doga@gmail.com", new DateTime(1989, 06, 11), "spect"));
        }

        [Test]
        public void CreateInvalidMentorTest()
        {
            Assert.Null(Mentor.Create(-100, "Senior", new DateTime(2021, 06, 21), "Mikee", "Wazowskiy", "doga@gmail.com", new DateTime(1989, 06, 11), "spect"));
        }
    }
}
