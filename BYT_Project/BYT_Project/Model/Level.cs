namespace BYT_Project.Model
{
    public class Level
    {
        public long Id {get; set;}
        public enum Name
        {
            Beginner,
            Intermidiate,
            Advanced
        }

        public Name name {get; set;}
        public List<Course>? Courses {get; set;}

        private static List<Level> _extent = [];



        public Level(long id, Name level)
        {
            Id = id;
            name = level;

            _extent.Add(this);

            ExtentManager.SaveExtent(_extent);
        }
    }
}