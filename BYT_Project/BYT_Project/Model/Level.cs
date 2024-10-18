using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYT_Project.Model
{
    public class Level
    {
        public long Id {get; set;}
        public enum Name
        {
            Beginner,
            Intermidiate,
            Advanced
        }
        public List<Course>? Courses {get; set;}
    }
}
