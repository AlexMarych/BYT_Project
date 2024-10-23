namespace BYT_Project.Model
{
    public class Level
    {
        public long Id { get; set; }
        public enum Name
        {
            Beginner,
            Intermidiate,
            Advanced
        }

        public Name name { get; set; }
        public List<Course>? Courses { get; set; }

        private static List<Level> _extent = [];

        public Level(Name level)
        {
            name = level;

            _extent.Add(this);
            ExtentManager.SaveExtent(_extent);
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {name}";
        }
    }
}