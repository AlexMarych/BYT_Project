namespace BYT_Project.Model
{
    public class TextAndVideo_Programming : Programming
    {
        private static List<TextAndVideo_Programming> _extent = [];
        public TextAndVideo_Programming(string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? tests) : base(name, price, mentors, level, tests)
        {
            _extent.Add(this);
        }
    }
}