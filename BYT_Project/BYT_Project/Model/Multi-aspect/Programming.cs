using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public abstract class Programming : Course
    {
        [Required(AllowEmptyStrings = false)]
        public string TechnologyName { get; set; }
        public List<string>? FrameworksList { get; set; }

        public Programming(string technologyName, List<string> frameworkList, string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel level, List<Test>? questions) : base(name, price, mentors, level, questions)
        {
            TechnologyName = technologyName;
            FrameworksList = frameworkList;
        }
    }
}