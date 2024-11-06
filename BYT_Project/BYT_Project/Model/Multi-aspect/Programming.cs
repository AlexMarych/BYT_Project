using BYT_Project.Utils;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class Programming : Course
    {
        [Required(AllowEmptyStrings = false)]
        public string TechnologyName { get; set; }
        public List<string>? FrameworksList { get; set; }

        private static List<Programming> _extent = [];

        static Programming()
        {
            _extent = ExtentManager.LoadExtent<Programming>();
        }

        public Programming(string technologyName, List<string> frameworkList, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? questions) : base(name, price, mentors, level, questions)
        {
            TechnologyName = technologyName;
            FrameworksList = frameworkList;

            _extent.Add(this);
            ExtentManager.ClearExtent<Programming>();
            ExtentManager.SaveExtent(_extent);
        }
    }
}