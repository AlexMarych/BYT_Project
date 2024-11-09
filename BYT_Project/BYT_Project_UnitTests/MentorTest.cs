using BYT_Project.Model;

namespace BYT_Project_UnitTests
{
    internal class MentorTest
    {
        Mentor mentor = new Mentor(1000, "Senior", new DateTime(2021, 06, 21), "Mike", "Wazowski",
        new DateTime(1989, 06, 11), new DateTime(2021, 06, 22), "spec");

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
        
    }
}
