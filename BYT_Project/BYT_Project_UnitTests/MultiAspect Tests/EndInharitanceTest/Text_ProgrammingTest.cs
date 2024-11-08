using BYT_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
