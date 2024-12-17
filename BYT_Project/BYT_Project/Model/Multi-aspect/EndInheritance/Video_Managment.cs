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

        public static Video_Managment? Create(TimeSpan overallDuration, int videosNumber, string field, Level level, string name, int price, DifficultyLevel difficultyLevel)
        {
            try
            {
                return new Video_Managment( overallDuration, videosNumber, field, level, name, price, null, difficultyLevel, null);
            }
            catch (ValidationException)
            {
                return null;
            }
        }

        public static void Modifiy(Video_Managment video_Managment)
        {

            Video_Managment modifiyable = _extent.First(x => x.Id == video_Managment.Id);

            _extent.Remove(modifiyable);
            _extent.Add(video_Managment);

            ExtentManager.ClearExtent<Video_Managment>();
            ExtentManager.SaveExtent(_extent);
        }

        public static void Delete(Video_Managment video_Managment)
        {
            _extent.Remove(video_Managment);
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
