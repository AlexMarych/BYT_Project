using BYT_Project.Utils;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;
using static BYT_Project.Model.Managment;

namespace BYT_Project.Model
{
    public class Text_Programming : Programming
    {
        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }
        public TimeSpan FamiliarizationTime { get; set; }

        private static List<Text_Programming> _extent = [];

        static Text_Programming()
        {
            _extent = ExtentManager.LoadExtent<Text_Programming>();
        }

        public Text_Programming(string content, TimeSpan familiarizationTime, string technologyName, List<string> frameworkList, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? questions) : base(technologyName, frameworkList, name, price, mentors, level, questions)
        {
            Content = content;
            FamiliarizationTime = familiarizationTime;

            CustomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<Text_Programming>();
            ExtentManager.SaveExtent(_extent);
        }

        public static Text_Programming? Create(string content, TimeSpan familiarizationTime, string technologyName, List<string> frameworkList, string name, int price, DifficultyLevel level)
        {
            try
            {
                return new Text_Programming(content, familiarizationTime, technologyName, frameworkList, name, price, null, level, null);
            }
            catch (ValidationException)
            {
                return null;
            }
        }

        public static void Modifiy(Text_Programming text_Programming)
        {

            Text_Programming modifiyable = _extent.First(x => x.Id == text_Programming.Id);

            _extent.Remove(modifiyable);
            _extent.Add(text_Programming);

            ExtentManager.ClearExtent<Text_Programming>();
            ExtentManager.SaveExtent(_extent);
        }

        public static void Delete(Text_Programming text_Programming)
        {
            _extent.Remove(text_Programming);
            ExtentManager.ClearExtent<Text_Programming>();
            ExtentManager.SaveExtent(_extent);
        }

        public override bool Equals(object? obj)
        {
            return obj is Text_Programming programming &&
                   base.Equals(obj) &&
                   Id == programming.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id);
        }
    }
}
