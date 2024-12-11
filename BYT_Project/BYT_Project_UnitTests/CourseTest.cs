using BYT_Project.Model;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;
using static BYT_Project.Model.Course;
using static BYT_Project.Model.Managment;

namespace BYT_Project_UnitTests
{

    internal class CourseTest
    {
        static IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

        static List<Test>? tests = new List<Test>();

        private static Level level;
        private static DifficultyLevel difficultyLevel;

        private static Course course = new Text_Managment("field", new(), "ss", level, "middle", 12, role, difficultyLevel, tests);

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
            Assert.IsInstanceOf<Course.DifficultyLevel>(course.difficultyLevel);
        }

        [Test]
        public void CourseDataValidationTest_Questions()
        {
            Assert.IsInstanceOf<List<Test>>(course.Tests);
        }

        [Test]
        public void CourseRangeValidationTest_Price()
        {
            Assert.Throws<ValidationException>(() => CustomValidator.Validate(
                new Text_Managment("field", new(), "ss", level, "middle", -1, role, difficultyLevel, tests)));
        }

        [Test]
        public void CourseEmptySringValidationTest_Name()
        {
            Assert.Throws<ValidationException>(() => CustomValidator.Validate(
                new Text_Managment("field", new(), "", level, "middle", 12, role, difficultyLevel, tests)));
        }

        [Test]
        public void CourseRelationValidationTest_SetRole()
        {
            Mentor mentor = new Mentor(1000, "Senior", new DateTime(2021, 06, 21), "Mike", "Wazowski", "dog@gmail.com",
                new DateTime(1989, 06, 11), new DateTime(2021, 06, 22), "spec", null);

            course.AddMentor("abc", mentor);
            Assert.That(course.Mentors["abc"], Is.EqualTo(mentor));

        }


    }
}
