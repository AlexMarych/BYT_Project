namespace BYT_Project.Model
{
    internal class Text_Managment : Managment
    {
        private static List<Text_Managment> _extent = [];
        public Text_Managment(string name, int price, IDictionary<string, Mentor>? mentors, Level level, List<Question>? questions) : base(name, price, mentors, level, questions)
        {
            _extent.Add(this);

            ExtentManager.SaveExtent(_extent);
        }
    }
}
