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
    internal class ManagmentTest
    {
        static IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

        static List<Test>? tests = new List<Test>();

        private static Level level;
        private static DifficultyLevel difficultyLevel;

        Managment managment = new Managment("field", level, "middle", 12, role, difficultyLevel, tests);

        [Test]
        public void ManagmentDataValidationTest_Field()
        {
            Assert.IsInstanceOf<string>(managment.Field);
        }

        [Test]
        public void ManagmentDataValidationTest_Level()
        {
            Assert.IsInstanceOf<Level>(managment.level);
        }
    }
}
