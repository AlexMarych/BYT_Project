using BYT_Project.Model;
using BYT_Project.Utils;
using static BYT_Project.Model.Course;
using static BYT_Project.Model.Managment;

namespace BYT_Project_UnitTests
{
    public class ExtentManagerTest
    {
        [Test]
        public void SerializeAndDeserializeTest()
        {
            var var = new Test(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), new()
            {
                new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"}),
                new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"}),
                new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"})
            });
            var list = ExtentManager.LoadExtent<Test>();

            Assert.That(list[^1], Is.EqualTo(var));
        }

        [Test]
        public void SerializeAndDeserializeSupport()
        {
            var var = new Support(5, "adad", new(), "da", "dada", "dog@gmail.com", new(), new(), []);
            var list = ExtentManager.LoadExtent<Support>();

            Assert.That(list[^1], Is.EqualTo(var));
        }

        [Test]
        public void SerializeAndDeserializeStudentTest()
        {
            var student = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21), new DateTime(2020, 08, 11), 1000, []);
            Test test = new(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), new()
            {
                new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"}),
                new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"}),
                new("Swofford?", "Sir yes sir!", new() { "ewew", "dadad"})
            });

            var var = new BYT_Project.Model.StudentTest(student, test, 5);
            var list = ExtentManager.LoadExtent<BYT_Project.Model.StudentTest>();

            Assert.That(list[^1], Is.EqualTo(var));
        }

        [Test]
        public void SerializeAndDeserializeStudent()
        {
            var var = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21), new DateTime(2020, 08, 11), 1000, []);
            var list = ExtentManager.LoadExtent<Student>();

            Assert.That(list[^1], Is.EqualTo(var));
        }

        [Test]
        public void SerializeAndDeserializeQuestion()
        {
            var var = new Question("Swofford?", "Sir yes sir!", new List<string>
            {
                "dadad",
                "dadada"
            });
            var list = ExtentManager.LoadExtent<Question>();

            Assert.That(list[^1], Is.EqualTo(var));
        }

        [Test]
        public void SerializeAndDeserializePetition()
        {
            var student = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21), new DateTime(2020, 08, 11), 1000, []);
            var var = new Petition(student,"petition", Petition.StatusType.Opened);
            var list = ExtentManager.LoadExtent<Petition>();

            Assert.That(list[^1], Is.EqualTo(var));
        }

        [Test]
        public void SerializeAndDeserializePayment()
        {
            var student = new Student("Mike", "Wazowski", "dog@gmail.com", new DateTime(2003, 07, 21), new DateTime(2020, 08, 11), 1000, []);
            var level = Level.Top;
            var difficultyLevel = DifficultyLevel.Intermidiate;
            var course = new Text_Managment("field", new(), "ss", level, "middle", 12, new Dictionary<string, Mentor>(), difficultyLevel, []);

            var var = new Payment(new DateTime(2023, 11, 11), student, course);
            var list = ExtentManager.LoadExtent<Payment>();

            Assert.That(list[^1], Is.EqualTo(var)); 
        }

        [Test]
        public void SerializeAndDeserializeMentor()
        {
            var var = new Mentor(1000, "Senior", new DateTime(2021, 06, 21), "Mike", "Wazowski", "dog@gmail.com", new DateTime(1989, 06, 11), new DateTime(2021, 06, 22), "spec", null);
            var list = ExtentManager.LoadExtent<Mentor>();

            Assert.That(list[^1], Is.EqualTo(var));
        }

        [Test]
        public void SerializeAndDeserializeProgramming()
        {
            IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

            List<Test>? tests = [];
            DifficultyLevel difficultyLevel = DifficultyLevel.Advanced;
            List<string> Techlist = [];

            var var = new Video_Programming(TimeSpan.Zero, 10, "java", Techlist, "name", 10, role, difficultyLevel, tests);

            var list = ExtentManager.LoadExtent<Video_Programming>();

            Assert.That(list[^1], Is.EqualTo(var));
        }

        [Test]
        public void SerializeAndDeserializeManagment()
        {
            IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

            List<Test>? tests = new();

            Level level = Level.Top;
            DifficultyLevel difficultyLevel = DifficultyLevel.Advanced;

            var var = new Video_Managment(TimeSpan.Zero, 10, "field", level, "middle", 12, role, difficultyLevel, tests);

            var list = ExtentManager.LoadExtent<Video_Managment>();

            Assert.That(list[^1], Is.EqualTo(var));
        }
    }
}