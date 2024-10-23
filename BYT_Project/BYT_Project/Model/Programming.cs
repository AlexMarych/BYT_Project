
namespace BYT_Project.Model
{
    public class Programming : Course
    {
        private static List<Programming> _extent = [];
        public Programming(string name, int price, IDictionary<string, Mentor>? mentors, Level level, List<Question>? questions) : base(name, price, mentors, level, questions)
        {
            _extent.Add(this);

            ExtentManager.SaveExtent(_extent);
        }
    }
}