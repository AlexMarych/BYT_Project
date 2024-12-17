using BYT_Project.Utils;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class Text_Managment : Managment
    {
        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        public TimeSpan FamiliarizationTime { get; set; }

        private static List<Text_Managment> _extent = [];

        static Text_Managment()
        {
            _extent = ExtentManager.LoadExtent<Text_Managment>();
        }

        public Text_Managment(string content, TimeSpan familiarizationTime, string field, Level level, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel difficultyLevel, List<Test>? tests) : base(field, level, name, price, mentors, difficultyLevel, tests)
        {
            Content = content;
            FamiliarizationTime = familiarizationTime;

            CustomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<Text_Managment>();
            ExtentManager.SaveExtent(_extent);
        }

        public static Text_Managment? Create(string content, TimeSpan familiarizationTime, string field, Level level, string name, int price, DifficultyLevel difficultyLevel)
        {
            try
            {
                return new Text_Managment(content, familiarizationTime, field, level, name, price, null, difficultyLevel, null);
            }
            catch (ValidationException)
            {
                return null;
            }
        }

        public static void Modifiy(Text_Managment text_Managment)
        {

            Text_Managment modifiyable = _extent.First(x => x.Id == text_Managment.Id);

            _extent.Remove(modifiyable);
            _extent.Add(text_Managment);

            ExtentManager.ClearExtent<Text_Managment>();
            ExtentManager.SaveExtent(_extent);
        }

        public static void Delete(Text_Managment text_Managment)
        {
            _extent.Remove(text_Managment);
            ExtentManager.ClearExtent<Text_Managment>();
            ExtentManager.SaveExtent(_extent);
        }

        public override bool Equals(object? obj)
        {
            return obj is Text_Managment managment &&
                   base.Equals(obj) &&
                   Id == managment.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id);
        }
    }
}
