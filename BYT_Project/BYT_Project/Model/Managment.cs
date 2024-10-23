
namespace BYT_Project.Model
{
    public class Managment : Course
    {
        private static List<Managment> _extent = [];

        public Managment(long id, string name, int price, IDictionary<string, Mentor>? mentors, Level level, List<Question>? questions) : base(id, name, price, mentors, level, questions)
        {

            _extent.Add(this);

            ExtentManager.SaveExtent(_extent);
        }


    }
}