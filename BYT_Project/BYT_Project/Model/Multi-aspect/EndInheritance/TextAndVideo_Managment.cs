using BYT_Project.Utils;
using BYT_Project.Utils.Validation;
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

            CustomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<TextAndVideo_Managment>();
            ExtentManager.SaveExtent(_extent);
        }

        public static TextAndVideo_Managment? Create(string content, TimeSpan familiarizationTime, TimeSpan overallDuration, int videosNumber, string field, Level level, string name, int price, DifficultyLevel difficultyLevel)
        {
            try
            {
                return new TextAndVideo_Managment(content, familiarizationTime,overallDuration,videosNumber, field, level,name,price,null,difficultyLevel,null);
            }
            catch (ValidationException)
            {
                return null;
            }
        }

        public static void Modifiy(TextAndVideo_Managment textAndVideo_Managment)
        {

            TextAndVideo_Managment modifiyable = _extent.First(x => x.Id == textAndVideo_Managment.Id);

            _extent.Remove(modifiyable);
            _extent.Add(textAndVideo_Managment);

            ExtentManager.ClearExtent<TextAndVideo_Managment>();
            ExtentManager.SaveExtent(_extent);
        }

        public static void Delete(TextAndVideo_Managment textAndVideo_Managment)
        {
            _extent.Remove(textAndVideo_Managment);
            ExtentManager.ClearExtent<TextAndVideo_Managment>();
            ExtentManager.SaveExtent(_extent);
        }

        public override bool Equals(object? obj)
        {
            return obj is TextAndVideo_Managment managment &&
                   base.Equals(obj) &&
                   Id == managment.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id);
        }
    }
}
