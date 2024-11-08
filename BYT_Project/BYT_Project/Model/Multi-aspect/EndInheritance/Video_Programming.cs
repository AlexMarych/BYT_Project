using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class Video_Programming : Programming
    {
        public TimeSpan OverallDuration { get; set; }

        [Range(0, int.MaxValue)]
        public int VideosNumber { get; set; }

        private static List<Video_Programming> _extent = [];

        static Video_Programming()
        {
            _extent = ExtentManager.LoadExtent<Video_Programming>();
        }

        public Video_Programming(TimeSpan overallDuration, int videosNumber, string technologyName, List<string> frameworkList, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? questions) : base(technologyName, frameworkList, name, price, mentors, level, questions)
        {
            OverallDuration = overallDuration;
            VideosNumber = videosNumber;

            CutsomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<Video_Programming>();
            ExtentManager.SaveExtent(_extent);
        }
    }
}
