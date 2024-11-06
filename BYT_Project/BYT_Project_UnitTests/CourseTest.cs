using BYT_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYT_Project_UnitTests
{

    internal class CourseTest
    {
        static IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

        static List<Test>? questions = new List<Test>();

        private static Managment.Level level;
        private static Course.DifficultyLevel difficultyLevel;

        Course course = new Managment("middle", level, "Mike", 10000, role, difficultyLevel, questions );
        
        
        [Test]
        public void CourseDataValidationTest_Name()
        {
            Assert.IsInstanceOf<string>(course.Name);
        }
        

        [Test]
        public void CourseDataValidationTest_Price()
        {
            Assert.IsInstanceOf<int>(course.Price);
        }
        

        [Test]
        public void CourseDataValidationTest_Mentors()
        {
            Assert.IsInstanceOf<IDictionary<string, Mentor>>(course.Mentors);
        }

        [Test]
        public void CourseDataValidationTest_DifficultyLevel()
        {
            Assert.IsInstanceOf<Course.DifficultyLevel>(course.Level);
        }

        [Test]
        public void CourseDataValidationTest_Questions()
        {
            Assert.IsInstanceOf<List<Test>>(course.Tests);
        }
    }
}
