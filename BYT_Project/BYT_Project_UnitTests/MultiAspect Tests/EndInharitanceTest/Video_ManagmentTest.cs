using BYT_Project.Model;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;
using static BYT_Project.Model.Course;
using static BYT_Project.Model.Managment;

namespace BYT_Project_UnitTests.MultiAspect_Tests.EndInharitanceTest
{
    internal class Video_ManagmentTest
    {
        static IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

        static List<Test>? tests = new List<Test>();

        private static Level level;
        private static DifficultyLevel difficultyLevel;

        Video_Managment video_Managment = new Video_Managment(TimeSpan.Zero, 10, "field",
            level, "middle", 12, role, difficultyLevel, tests);


        [Test]
        public void Video_ManagmentDataValidationTest_OverallDuration()
        {
            Assert.IsInstanceOf<TimeSpan>(video_Managment.OverallDuration);
        }

        [Test]
        public void Video_ManagmentDataValidationTest_VideosNumber()
        {
            Assert.IsInstanceOf<int>(video_Managment.VideosNumber);
        }

        [Test]
        public void Video_ManagmentDataValidationTest_Field()
        {
            Assert.IsInstanceOf<string>(video_Managment.Field);
        }

        [Test]
        public void Video_ManagmentDataValidationTest_Level()
        {
            Assert.IsInstanceOf<Level>(video_Managment.level);
        }
        [Test]
        public void Video_ManagmentRangeValidationTest_VideosNumber()
        {
            Assert.Throws<ValidationException>(() => CustomValidator.Validate(
                new Video_Managment(TimeSpan.Zero, -1, "field",
            level, "middle", 12, role, difficultyLevel, tests)));
        }
    }
}
