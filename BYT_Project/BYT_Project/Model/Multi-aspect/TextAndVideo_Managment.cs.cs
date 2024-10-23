namespace BYT_Project.Model
{
    internal class TextAndVideo_Managment : Managment
    {
        private static List<TextAndVideo_Managment> _extent = [];
        public TextAndVideo_Managment(string name, int price, IDictionary<string, Mentor>? mentors, Level level, List<Question>? questions) : base(name, price, mentors, level, questions)
        {
            _extent.Add(this);

            ExtentManager.SaveExtent(_extent);
        }
    }
}
