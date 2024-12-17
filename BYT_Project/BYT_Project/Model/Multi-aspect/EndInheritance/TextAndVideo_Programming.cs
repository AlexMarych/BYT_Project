using BYT_Project.Utils;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;
using static BYT_Project.Model.Managment;

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

        public static TextAndVideo_Programming? Create(string content, TimeSpan familiarizationTime, TimeSpan overallDuration, int videosNumber, string technologyName, List<string> frameworkList, string name, int price, DifficultyLevel level)
        {
            try
            {
                return new TextAndVideo_Programming(content, familiarizationTime, overallDuration, videosNumber,technologyName, frameworkList, name, price, null, level, null);
            }
            catch (ValidationException)
            {
                return null;
            }
        }

        public static void Modifiy(TextAndVideo_Programming textAndVideo_Programming)
        {

            TextAndVideo_Programming modifiyable = _extent.First(x => x.Id == textAndVideo_Programming.Id);

            _extent.Remove(modifiyable);
            _extent.Add(textAndVideo_Programming);

            ExtentManager.ClearExtent<TextAndVideo_Programming>();
            ExtentManager.SaveExtent(_extent);
        }

        public static void Delete(TextAndVideo_Programming textAndVideo_Programming)
        {
            _extent.Remove(textAndVideo_Programming);
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