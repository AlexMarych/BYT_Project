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
        private static IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

        private static List<Test>? tests = new List<Test>();

        private static Level level;
        private static DifficultyLevel difficultyLevel;

        private static Managment course = new Text_Managment("field", new(), "ss", level, "middle", 12, role, difficultyLevel, []);

        [Test]
        public void ManagmentDataValidationTest_Field()
        {
            Assert.IsInstanceOf<string>(course.Field);
        }

        [Test]
        public void ManagmentDataValidationTest_Level()
        {
            Assert.IsInstanceOf<Level>(course.level);
        }
    }
}
