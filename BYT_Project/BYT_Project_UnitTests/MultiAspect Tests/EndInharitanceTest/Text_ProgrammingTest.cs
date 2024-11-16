using BYT_Project.Model;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;
using static BYT_Project.Model.Course;

namespace BYT_Project_UnitTests.MultiAspect_Tests.EndInharitanceTest
{
    internal class Text_ProgrammingTest
    {
        static IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

        static List<Test>? tests = new List<Test>();


        private static DifficultyLevel difficultyLevel;
        private static List<string> Techlist = new List<string>();

        Text_Programming text_Programming = new Text_Programming("content", TimeSpan.Zero, "java", Techlist, "name", 10, role, difficultyLevel, tests);

        [Test]
        public void TextA_ProgrammingDataValidationTest_Content()
        {
            Assert.IsInstanceOf<string>(text_Programming.Content);
        }

        [Test]
        public void Text_ProgrammingDataValidationTest_FamiliarizationTime()
        {
            Assert.IsInstanceOf<TimeSpan>(text_Programming.FamiliarizationTime);
        }

        [Test]
        public void Text_ProgrammingDataValidationTest_TechnologyName()
        {
            Assert.IsInstanceOf<string>(text_Programming.TechnologyName);
        }

        [Test]
        public void Text_ProgrammingDataValidationTest_FrameworksList()
        {
            Assert.IsInstanceOf<List<string>?>(text_Programming.FrameworksList);
        }

        [Test]
        public void Text_ProgrammingEmptySringValidationTest_TechnologyName()
        {
            Assert.Throws<ValidationException>(() => CustomValidator.Validate(
                new Text_Programming("content", TimeSpan.Zero, "", Techlist, "name", 10, role, difficultyLevel, tests)));
        }
    }
}
