namespace BYT_Project.Model
{
    public abstract class Course
    {
        public long Id { get; }
        public required string Name { get; set; }
        public int Price { get; set; }
        public static float MinScore = 0.5f;

        public IDictionary<string, Mentor>? Mentors { get; set; }

        public required Level Level { get; set; }

        public List<Question>? Questions { get; set; }

        
    }
}