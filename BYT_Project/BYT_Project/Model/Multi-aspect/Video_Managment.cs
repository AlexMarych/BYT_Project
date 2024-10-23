namespace BYT_Project.Model
{
    internal class Video_Managment : Managment
    {
        private static List<Video_Managment> _extent = [];
        public Video_Managment(string name, int price, IDictionary<string, Mentor>? mentors, Level level, List<Question>? questions) : base(name, price, mentors, level, questions)
        {
            _extent.Add(this);

            ExtentManager.SaveExtent(_extent);
        }
    }
}
