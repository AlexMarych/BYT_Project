using BYT_Project.Model;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;
using static BYT_Project.Model.Course;
using static BYT_Project.Model.Managment;

namespace BYT_Project_UnitTests.MultiAspect_Tests
{
    internal class ProgrammingTest
    {
        static IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

        static List<Test>? tests = new List<Test>();

        private static DifficultyLevel difficultyLevel;
        private static List<string> listOfFrameworks = new();

        private static Programming programming = new Text_Programming("Java", new(), "fff", listOfFrameworks, "middle", 12, role, difficultyLevel, tests);

        [Test]
        public void ProgrammingDataValidationTest_TechnologyName()
        {
            Assert.IsInstanceOf<string>(programming.TechnologyName);
        }

        [Test]
        public void ProgrammingDataValidationTest_FrameworksList()
        {
            Assert.IsInstanceOf<List<string>?>(programming.FrameworksList);
        }

        [Test]
        public void ProgrammingEmptySringValidationTest_TechnologyName()
        {
            Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
                new Text_Programming("", new(), "fff", listOfFrameworks, "middle", 12, role, difficultyLevel, tests)));
        }
    }
}
