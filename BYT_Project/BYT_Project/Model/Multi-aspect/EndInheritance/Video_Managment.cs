
namespace BYT_Project.Model
{
    public class Video_Managment : Managment
    {
        public TimeSpan OverallDuration { get; set; }
        public int VideosNumber { get; set; }

        private static List<Video_Managment> _extent = [];
        public Video_Managment(TimeSpan overallDuration, int videosNumber, string field, Level level, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel difficultyLevel, List<Test>? tests) : base(field, level, name, price, mentors, difficultyLevel, tests)
        {
            this.OverallDuration = overallDuration;
            this.VideosNumber = videosNumber;
            _extent.Add(this);
        }
    }
}
