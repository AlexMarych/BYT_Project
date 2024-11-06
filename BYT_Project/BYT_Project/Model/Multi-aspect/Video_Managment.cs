namespace BYT_Project.Model
{
    public class Video_Managment : Managment
    {
        public TimeSpan OverallDuration { get; set; }
        public int VideosNumber { get; set; }
        private static List<Video_Managment> _extent = [];
        public Video_Managment(string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? tests) : base(name, price, mentors, level, tests)
        {
            _extent.Add(this);
        }
    }
}
