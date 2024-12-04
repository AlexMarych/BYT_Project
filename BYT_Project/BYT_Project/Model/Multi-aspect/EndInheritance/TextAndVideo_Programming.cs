using BYT_Project.Utils;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class TextAndVideo_Programming : Programming
    {
        [Required(AllowEmptyStrings= false)]
        public string Content { get; set; }

        public TimeSpan FamiliarizationTime { get; set; }
        public TimeSpan OverallDuration { get; set; }

        [Range(0, int.MaxValue)]
        public int VideosNumber { get; set; }

        private static List<TextAndVideo_Programming> _extent = [];

        static TextAndVideo_Programming()
        {
            _extent = ExtentManager.LoadExtent<TextAndVideo_Programming>();
        }

        public TextAndVideo_Programming(string content, TimeSpan familiarizationTime, TimeSpan overallDuration, int videosNumber, string technologyName, List<string> frameworkList, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? questions) : base(technologyName, frameworkList, name, price, mentors, level, questions)
        {
            Content = content;
            FamiliarizationTime = familiarizationTime;
            OverallDuration = overallDuration;
            VideosNumber = videosNumber;

            CustomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<TextAndVideo_Programming>();
            ExtentManager.SaveExtent(_extent);
        }

        public override bool Equals(object? obj)
        {
            return obj is TextAndVideo_Programming programming &&
                   base.Equals(obj) &&
                   Id == programming.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id);
        }
    }
}