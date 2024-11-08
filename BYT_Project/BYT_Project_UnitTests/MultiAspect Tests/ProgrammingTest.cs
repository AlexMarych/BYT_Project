using BYT_Project.Model;
using static BYT_Project.Model.Course;

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
    }
}
