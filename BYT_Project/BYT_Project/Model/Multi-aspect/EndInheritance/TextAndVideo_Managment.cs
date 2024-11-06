
namespace BYT_Project.Model
{
    public class TextAndVideo_Managment : Managment
    {
        public string Content { get; set; }
        public TimeSpan FamiliarizationTime { get; set; }
        public TimeSpan OverallDuration { get; set; }
        public int VideosNumber { get; set; }

        private static List<TextAndVideo_Managment> _extent = [];

        public TextAndVideo_Managment(string content, TimeSpan familiarizationTime, TimeSpan overallDuration, int videosNumber, string field, Level level, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel difficultyLevel, List<Test>? tests) : base(field, level, name, price, mentors, difficultyLevel, tests)
        {
            this.Content = content;
            this.FamiliarizationTime = familiarizationTime;
            this.OverallDuration = overallDuration;
            this.VideosNumber = videosNumber;
            _extent.Add(this);
        }
    }
}
