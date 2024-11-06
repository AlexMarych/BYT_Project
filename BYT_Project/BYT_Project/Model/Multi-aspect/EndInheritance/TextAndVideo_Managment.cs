using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class TextAndVideo_Managment : Managment
    {
        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        public TimeSpan FamiliarizationTime { get; set; }
        public TimeSpan OverallDuration { get; set; }

        [Range(0, int.MaxValue)]
        public int VideosNumber { get; set; }

        private static List<TextAndVideo_Managment> _extent = [];

        static TextAndVideo_Managment()
        {
            _extent = ExtentManager.LoadExtent<TextAndVideo_Managment>();
        }

        public TextAndVideo_Managment(string content, TimeSpan familiarizationTime, TimeSpan overallDuration, int videosNumber, string field, Level level, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel difficultyLevel, List<Test>? tests) : base(field, level, name, price, mentors, difficultyLevel, tests)
        {
            Content = content;
            FamiliarizationTime = familiarizationTime;
            OverallDuration = overallDuration;
            VideosNumber = videosNumber;

            CutsomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<TextAndVideo_Managment>();
            ExtentManager.SaveExtent(_extent);
        }
    }
}
