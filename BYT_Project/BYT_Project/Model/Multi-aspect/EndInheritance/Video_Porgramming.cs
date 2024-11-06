
namespace BYT_Project.Model
{
    public class Video_Porgramming : Programming
    {
        public TimeSpan OverallDuration { get; set; }
        public int VideosNumber { get; set; }

        private static List<Video_Porgramming> _extent = [];

        public Video_Porgramming(TimeSpan overallDuration, int videosNumber, string technologyName, List<string> frameworkList, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? questions) : base(technologyName, frameworkList, name, price, mentors, level, questions)
        {
            this.OverallDuration = overallDuration;
            this.VideosNumber = videosNumber;
            _extent.Add(this);
        }
    }
}
