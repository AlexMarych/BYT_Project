using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYT_Project.Model
{
    public class Video_Porgramming : Programming
    {
        private static List<Video_Porgramming> _extent = [];
        public Video_Porgramming(long id, string name, int price, IDictionary<string, Mentor>? mentors, Level level, List<Question>? questions) : base(id, name, price, mentors, level, questions)
        {
            _extent.Add(this);

            ExtentManager.SaveExtent(_extent);
        }
    }
}
