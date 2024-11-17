using BYT_Project.Model;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project_UnitTests
{
    public class SupportClassTest
    {
        private static Support support = new Support(5, "adad", new(), "da", "dada", "dog@gmail.com", new(), new(), []);

        [Test]
        public void SupportDataValidationTest_Salary()
        {
            Assert.IsInstanceOf<int>(support.Salary);
        }

        [Test]
        public void SupportDataValidationTest_Experience()
        {
            Assert.IsInstanceOf<string>(support.Experience);
        }

        [Test]
        public void SupportDataValidationTest_DateOfEmp()
        {
            Assert.IsInstanceOf<DateTime>(support.DateOfEmployment);
        }

        [Test]
        public void SupportDataValidationTest_Name()
        {
            Assert.IsInstanceOf<string>(support.Name);
        }

        [Test]
        public void SupportDataValidationTest_Surname()
        {
            Assert.IsInstanceOf<string>(support.Surname);
        }

        [Test]
        public void SupportDataValidationTest_Email()
        {
            Assert.IsInstanceOf<string>(support.Email);
        }

        [Test]
        public void SupportDataValidationTest_DateOfBirth()
        {
            Assert.IsInstanceOf<DateTime>(support.DateOfBirth);
        }

        [Test]
        public void SupportDataValidationTest_CreatedAt()
        {
            Assert.IsInstanceOf<DateTime>(support.CreatedAt);
        }

        [Test]
        public void SupportDataValidationTest_SalaryBonus()
        {
            Assert.IsInstanceOf<int>(support.SalaryBonus);
        }

        [Test]
        public void SupportRangeVlidationTest_SalaryBonus()
        {
            Assert.Throws<ValidationException>(() => CustomValidator.Validate(
                new Support(-5, "adad", new(), "da", "dada", "dog@gmail.com", new(), new(), [])));
        }
    }
}
