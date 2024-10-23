using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYT_Project.Model
{
    internal class TextAndVideo_Programming : Programming
    {
        private static List<TextAndVideo_Programming> _extent = [];
        public TextAndVideo_Programming(long id, string name, int price, IDictionary<string, Mentor>? mentors, Level level, List<Question>? questions) : base(id, name, price, mentors, level, questions)
        {
            _extent.Add(this);

            ExtentManager.SaveExtent(_extent);
        }
    }
}
