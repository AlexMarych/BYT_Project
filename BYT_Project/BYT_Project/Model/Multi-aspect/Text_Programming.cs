namespace BYT_Project.Model
{
    public class Text_Programming : Programming
    {
        private static List<Text_Programming> _extent = [];
        public Text_Programming(string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? tests) : base(name, price, mentors, level, tests)
        {
            _extent.Add(this);
        }
    }
}
