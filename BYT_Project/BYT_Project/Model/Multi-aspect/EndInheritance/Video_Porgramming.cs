using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class Video_Porgramming : Programming
    {
        public TimeSpan OverallDuration { get; set; }

        [Range(0, int.MaxValue)]
        public int VideosNumber { get; set; }

        private static List<Video_Porgramming> _extent = [];

        static Video_Porgramming()
        {
            _extent = ExtentManager.LoadExtent<Video_Porgramming>();
        }

        public Video_Porgramming(TimeSpan overallDuration, int videosNumber, string technologyName, List<string> frameworkList, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? questions) : base(technologyName, frameworkList, name, price, mentors, level, questions)
        {
            OverallDuration = overallDuration;
            VideosNumber = videosNumber;

            CutsomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<Video_Porgramming>();
            ExtentManager.SaveExtent(_extent);
        }
    }
}
