
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class Programming : Course
    {
        [Required(AllowEmptyStrings = false)]
        public string TechnologyName { get; set; }
        public List<string>? FrameworksList { get; set; }

        private static List<Programming> _extent = [];
        public Programming(string technologyName, List<string> frameworkList, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? questions) : base(name, price, mentors, level, questions)
        {
            this.TechnologyName = technologyName;
            this.FrameworksList = frameworkList;
            _extent.Add(this);
        }
    }
}