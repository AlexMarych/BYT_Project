using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public abstract class Managment : Course
    {
        [Required(AllowEmptyStrings = false)]
        public string Field { get; set; }

        public enum Level
        {
            Top,
            Middle,
            Low
        }

        public Level level { get; set; }

        public Managment(string field, Level level, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel difficultyLevel, List<Test>? tests) : base(name, price, mentors, difficultyLevel, tests)
        {
            Field = field;
            this.level = level;
        }

        public override bool Equals(object? obj)
        {
            return obj is Managment managment &&
                   base.Equals(obj) &&
                   Id == managment.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id);
        }

    }
}