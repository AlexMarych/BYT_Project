
using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class Text_Programming : Programming
    {
        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }
        public TimeSpan FamiliarizationTime { get; set; }

        private static List<Text_Programming> _extent = [];

        public Text_Programming(string content, TimeSpan familiarizationTime, string technologyName, List<string> frameworkList, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? questions) : base(technologyName, frameworkList, name, price, mentors, level, questions)
        {
            Content = content;
            FamiliarizationTime = familiarizationTime;

            CutsomValidator.Validate(this);

            _extent.Add(this);
        }
    }
}
