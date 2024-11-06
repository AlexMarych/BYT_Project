
using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class Video_Managment : Managment
    {
        public TimeSpan OverallDuration { get; set; }

        [Range(0, int.MaxValue)]
        public int VideosNumber { get; set; }

        private static List<Video_Managment> _extent = [];
        public Video_Managment(TimeSpan overallDuration, int videosNumber, string field, Level level, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel difficultyLevel, List<Test>? tests) : base(field, level, name, price, mentors, difficultyLevel, tests)
        {
            OverallDuration = overallDuration;
            VideosNumber = videosNumber;

            CutsomValidator.Validate(this);

            _extent.Add(this);
        }
    }
}
