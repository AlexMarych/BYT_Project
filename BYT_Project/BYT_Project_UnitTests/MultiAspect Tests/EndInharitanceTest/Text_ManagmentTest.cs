using BYT_Project.Model;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;
using static BYT_Project.Model.Course;
using static BYT_Project.Model.Managment;

namespace BYT_Project_UnitTests.MultiAspect_Tests.EndInharitanceTest
{
    internal class Text_ManagmentTest
    {
        static IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

        static List<Test>? tests = new List<Test>();

        private static Level level;
        private static DifficultyLevel difficultyLevel;

        Text_Managment text_Managment = new Text_Managment("content", TimeSpan.Zero, "field",
            level, "middle", 12, role, difficultyLevel, tests);

        [Test]
        public void Text_ManagmentDataValidationTest_Content()
        {
            Assert.IsInstanceOf<string>(text_Managment.Content);
        }

        [Test]
        public void Text_ManagmentDataValidationTest_FamiliarizationTime()
        {
            Assert.IsInstanceOf<TimeSpan>(text_Managment.FamiliarizationTime);
        }

        [Test]
        public void Text_ManagmentDataValidationTest_Field()
        {
            Assert.IsInstanceOf<string>(text_Managment.Field);
        }

        [Test]
        public void Text_ManagmentDataValidationTest_Level()
        {
            Assert.IsInstanceOf<Level>(text_Managment.level);
        }

        [Test]
        public void Text_ManagmentEmptySringValidationTest_Content()
        {
            Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
                new Text_Managment("", TimeSpan.Zero, "field",
            level, "middle", 12, role, difficultyLevel, tests)));
        }
    }
}
