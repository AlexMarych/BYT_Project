using BYT_Project.Utils;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class Video_Managment : Managment
    {
        public TimeSpan OverallDuration { get; set; }

        [Range(0, int.MaxValue)]
        public int VideosNumber { get; set; }

        private static List<Video_Managment> _extent = [];

        static Video_Managment()
        {
            _extent = ExtentManager.LoadExtent<Video_Managment>();
        }

        public Video_Managment(TimeSpan overallDuration, int videosNumber, string field, Level level, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel difficultyLevel, List<Test>? tests) : base(field, level, name, price, mentors, difficultyLevel, tests)
        {
            OverallDuration = overallDuration;
            VideosNumber = videosNumber;

            CustomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<Video_Managment>();
            ExtentManager.SaveExtent(_extent);
        }

        public override bool Equals(object? obj)
        {
            return obj is Video_Managment managment &&
                   base.Equals(obj) &&
                   Id == managment.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id);
        }
    }
}
