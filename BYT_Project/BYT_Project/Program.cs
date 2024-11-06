using BYT_Project.Model;
using static BYT_Project.Model.Course;
using static BYT_Project.Model.Managment;

Console.WriteLine("Class extents");

Student student =
    new Student("Mike", "Wazowski", new DateTime(2003, 07, 21),
        new DateTime(2020, 08, 11), 12000, 4);

IDictionary<string, Mentor> role = new Dictionary<string, Mentor>();

List<Test>? questions = new List<Test>();

Managment.Level level;
Course.DifficultyLevel difficultyLevel;
Managment course = new Managment("middle", Managment.Level.Top, "Mike", 10000, role, Course.DifficultyLevel.Intermidiate, questions);

Payment payment = new Payment(new DateTime(2023, 11, 11), student, course);