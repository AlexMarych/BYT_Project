using BYT_Project.Model;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;
using static BYT_Project.Model.Course;

namespace BYT_Project_UnitTests.MultiAspect_Tests.EndInharitanceTest
{
    internal class TextAndVideo_ProgrammingTest
    {
        static IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

        static List<Test>? tests = new List<Test>();

        
        private static DifficultyLevel difficultyLevel;
        private static List<string> Techlist = new List<string>();

        TextAndVideo_Programming textAndVideo_Programming = new TextAndVideo_Programming("content", TimeSpan.Zero, TimeSpan.Zero, 10, "java", Techlist, "name", 10, role, difficultyLevel, tests);

        [Test]
        public void TextAndVideo_ProgrammingDataValidationTest_Content()
        {
            Assert.IsInstanceOf<string>(textAndVideo_Programming.Content);
        }

        [Test]
        public void TextAndVideo_ProgrammingDataValidationTest_FamiliarizationTime()
        {
            Assert.IsInstanceOf<TimeSpan>(textAndVideo_Programming.FamiliarizationTime);
        }

        [Test]
        public void TextAndVideo_ProgrammingDataValidationTest_OverallDuration()
        {
            Assert.IsInstanceOf<TimeSpan>(textAndVideo_Programming.OverallDuration);
        }

        [Test]
        public void TextAndVideo_ProgrammingDataValidationTest_VideosNumber()
        {
            Assert.IsInstanceOf<int>(textAndVideo_Programming.VideosNumber);
        }

        [Test]
        public void TextAndVideo_ProgrammingDataValidationTest_TechnologyName()
        {
            Assert.IsInstanceOf<string>(textAndVideo_Programming.TechnologyName);
        }

        [Test]
        public void TextAndVideo_ProgrammingDataValidationTest_FrameworksList()
        {
            Assert.IsInstanceOf<List<string>?>(textAndVideo_Programming.FrameworksList);
        }

        [Test]
        public void TextAndVideo_ProgrammingRangeValidationTest_VideosNumber()
        {
            Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
                new TextAndVideo_Programming("content", TimeSpan.Zero, TimeSpan.Zero, -1, "java", Techlist, "name", 10, role, difficultyLevel, tests)));
        }

        [Test]
        public void TextAndVideo_ProgrammingEmptySringValidationTest_TechnologyName()
        {
            Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
                new TextAndVideo_Programming("content", TimeSpan.Zero, TimeSpan.Zero, 10, "", Techlist, "name", 10, role, difficultyLevel, tests)));
        }
    }
}
