using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    [Serializable]
    public abstract class Course
    {
        public long Id { get; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public enum DifficultyLevel
        {
            Beginner,
            Intermidiate,
            Advanced
        }

        public DifficultyLevel Level { get; set; }
        public int Price { get; set; }
        public static float MinScore = 0.5f;

        protected Course(string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel difficulty, List<Test>? tests)
        {
            Name = name;
            Price = price;
            Mentors = mentors;
            Level = difficulty;
            Tests = tests;
        }

        public IDictionary<string, Mentor>? Mentors { get; set; }

        public List<Test>? Tests { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}";
        }
    }
}