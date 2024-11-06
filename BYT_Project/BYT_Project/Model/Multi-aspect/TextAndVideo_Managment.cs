namespace BYT_Project.Model
{
    public class TextAndVideo_Managment : Managment
    {
        private static List<TextAndVideo_Managment> _extent = [];
        public TextAndVideo_Managment(string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? tests) : base(name, price, mentors, level, tests)
        {
            _extent.Add(this);
        }
    }
}
