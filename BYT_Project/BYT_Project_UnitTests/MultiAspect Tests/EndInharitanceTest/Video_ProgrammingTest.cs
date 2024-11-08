using BYT_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BYT_Project.Model.Course;

namespace BYT_Project_UnitTests.MultiAspect_Tests.EndInharitanceTest
{
    internal class Video_ProgrammingTest
    {
        static IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

        static List<Test>? tests = new List<Test>();


        private static DifficultyLevel difficultyLevel;
        private static List<string> Techlist = new List<string>();

        Video_Programming video_Programming = new Video_Programming(TimeSpan.Zero, 10, "java", Techlist, "name", 10, role, difficultyLevel, tests);


        [Test]
        public void Video_ProgrammingDataValidationTest_OverallDuration()
        {
            Assert.IsInstanceOf<TimeSpan>(video_Programming.OverallDuration);
        }

        [Test]
        public void Video_ProgrammingDataValidationTest_VideosNumber()
        {
            Assert.IsInstanceOf<int>(video_Programming.VideosNumber);
        }

        [Test]
        public void Video_ProgrammingDataValidationTest_TechnologyName()
        {
            Assert.IsInstanceOf<string>(video_Programming.TechnologyName);
        }

        [Test]
        public void Video_ProgrammingDataValidationTest_FrameworksList()
        {
            Assert.IsInstanceOf<List<string>?>(video_Programming.FrameworksList);
        }
    }
}
