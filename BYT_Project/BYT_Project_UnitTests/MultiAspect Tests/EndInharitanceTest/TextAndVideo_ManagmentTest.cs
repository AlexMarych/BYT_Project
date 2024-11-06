using BYT_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BYT_Project.Model.Course;
using static BYT_Project.Model.Managment;

namespace BYT_Project_UnitTests.MultiAspect_Tests.EndInharitanceTest
{
    internal class TextAndVideo_ManagmentTest
    {
        static IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

        static List<Test>? tests = new List<Test>();

        private static Level level;
        private static DifficultyLevel difficultyLevel;

        TextAndVideo_Managment textAndVideo_Managment = new TextAndVideo_Managment("content", TimeSpan.Zero, TimeSpan.Zero, 10,"field", 
            level, "middle", 12, role, difficultyLevel, tests);

        [Test]
        public void TextAndVideo_ManagmentDataValidationTest_Content()
        {
            Assert.IsInstanceOf<string>(textAndVideo_Managment.Content);
        }

        [Test]
        public void TextAndVideo_ManagmentDataValidationTest_FamiliarizationTime()
        {
            Assert.IsInstanceOf<TimeSpan>(textAndVideo_Managment.FamiliarizationTime);
        }
        
        [Test]
        public void TextAndVideo_ManagmentDataValidationTest_OverallDuration()
        {
            Assert.IsInstanceOf<TimeSpan>(textAndVideo_Managment.OverallDuration);
        }

        [Test]
        public void TextAndVideo_ManagmentDataValidationTest_VideosNumber()
        {
            Assert.IsInstanceOf<int>(textAndVideo_Managment.VideosNumber);
        }
    }
}
