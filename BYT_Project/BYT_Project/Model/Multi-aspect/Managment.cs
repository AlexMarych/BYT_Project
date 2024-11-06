
using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class Managment : Course
    {
        [Required(AllowEmptyStrings = false)]
        public string Field { get; set; }

        public enum Level
        {
            Top,
            Middle,
            Low
        }

        [Required]
        public Level level { get; set; }
        
        private static List<Managment> _extent = [];

        public Managment(string field, Level level, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel difficultyLevel, List<Test>? tests) : base(name, price, mentors, difficultyLevel, tests)
        {
            Field = field;
            this.level = level;

            _extent.Add(this);
        }


    }
}