

namespace BYT_Project.Model
{
    public class Text_Managment : Managment
    {
        public string Content { get; set; }

        public TimeSpan FamiliarizationTime { get; set; }

        private static List<Text_Managment> _extent = [];

        public Text_Managment(string content, TimeSpan familiarizationTime, string field, Level level, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel difficultyLevel, List<Test>? tests) : base(field, level, name, price, mentors, difficultyLevel, tests)
        {
            this.Content = content;
            this.FamiliarizationTime = familiarizationTime;
            _extent.Add(this);
        }
    }
}
