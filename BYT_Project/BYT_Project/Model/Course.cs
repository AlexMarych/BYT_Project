using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    [Serializable]
    public abstract class Course
    {
        public long Id { get; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public int Price { get; set; }
        public static float MinScore = 0.5f;

        protected Course(string name, int price, IDictionary<string, Mentor>? mentors, Level level, List<Question>? questions)
        {
            Name = name;
            Price = price;
            Mentors = mentors;
            Level = level;
            Questions = questions;
        }

        public IDictionary<string, Mentor>? Mentors { get; set; }

        public  Level Level { get; set; }

        public List<Question>? Questions { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}";
        }
    }
}