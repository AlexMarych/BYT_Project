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

        static List<Question> questions = new List<Question>();

        Course course = new Managment("name", 20000, role, Course.Level.Advanced, questions);

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
        public void CourseDataValidationTest_Level()
        {
            Assert.IsInstanceOf<Course.Level>(course.level);
        }

        [Test]
        public void CourseDataValidationTest_Questions()
        {
            Assert.IsInstanceOf<List<Question>>(course.Questions);
        }
    }
}
