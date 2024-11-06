

using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class Text_Managment : Managment
    {
        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }

        public TimeSpan FamiliarizationTime { get; set; }

        private static List<Text_Managment> _extent = [];

        public Text_Managment(string content, TimeSpan familiarizationTime, string field, Level level, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel difficultyLevel, List<Test>? tests) : base(field, level, name, price, mentors, difficultyLevel, tests)
        {
            Content = content;
            FamiliarizationTime = familiarizationTime;

            CutsomValidator.Validate(this);

            _extent.Add(this);
        }
    }
}
