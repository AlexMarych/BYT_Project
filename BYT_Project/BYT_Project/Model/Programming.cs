
namespace BYT_Project.Model
{
    public class Programming : Course
    {
        private static List<Programming> _extent = [];
        public Programming(long id, string name, int price, IDictionary<string, Mentor>? mentors, Level level, List<Question>? questions) : base(id, name, price, mentors, level, questions)
        {
            _extent.Add(this);

            ExtentManager.SaveExtent(_extent);
        }
    }
}