namespace BYT_Project.Model
{
    public class Text_Managment : Managment
    {
        private static List<Text_Managment> _extent = [];
        public Text_Managment(string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? tests) : base(name, price, mentors, level, tests)
        {
            _extent.Add(this);
        }
    }
}
