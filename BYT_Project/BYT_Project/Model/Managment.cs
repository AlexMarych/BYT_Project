
namespace BYT_Project.Model
{
    public class Managment : Course
    {
        private static List<Managment> _extent = [];

        public Managment(string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? questions) : base(name, price, mentors, level, questions)
        {
            _extent.Add(this);
        }


    }
}