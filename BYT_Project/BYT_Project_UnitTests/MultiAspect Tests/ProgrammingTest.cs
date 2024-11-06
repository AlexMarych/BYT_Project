using BYT_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        Programming programming = new Programming("Java", listOfFrameworks, "middle", 12, role, difficultyLevel, tests);

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
