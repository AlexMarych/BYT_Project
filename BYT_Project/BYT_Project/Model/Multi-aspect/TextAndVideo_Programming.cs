namespace BYT_Project.Model
{
    internal class TextAndVideo_Programming : Programming
    {
        private static List<TextAndVideo_Programming> _extent = [];
        public TextAndVideo_Programming(string name, int price, IDictionary<string, Mentor>? mentors, Level level, List<Question>? questions) : base(name, price, mentors, level, questions)
        {
            _extent.Add(this);

            ExtentManager.SaveExtent(_extent);
        }
    }
}
