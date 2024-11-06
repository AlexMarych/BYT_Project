
namespace BYT_Project.Model
{
    public class TextAndVideo_Programming : Programming
    {
        public string Content { get; set; }
        public TimeSpan FamiliarizationTime { get; set; }
        public TimeSpan OverallDuration { get; set; }
        public int VideosNumber { get; set; }

        private static List<TextAndVideo_Programming> _extent = [];

        public TextAndVideo_Programming(string content, TimeSpan familiarizationTime, TimeSpan overallDuration, int videosNumber, string technologyName, List<string> frameworkList, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? questions) : base(technologyName, frameworkList, name, price, mentors, level, questions)
        {
            this.Content = content;
            this.FamiliarizationTime = familiarizationTime;
            this.OverallDuration = overallDuration;
            this.VideosNumber = videosNumber;
            _extent.Add(this);
        }
    }
}