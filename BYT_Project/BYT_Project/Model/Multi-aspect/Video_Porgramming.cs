namespace BYT_Project.Model
{
    public class Video_Porgramming : Programming
    {
        private static List<Video_Porgramming> _extent = [];
        public Video_Porgramming(string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? tests) : base(name, price, mentors, level, tests)
        {
            _extent.Add(this);
        }
    }
}
