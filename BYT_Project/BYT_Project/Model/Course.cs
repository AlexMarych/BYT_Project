using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYT_Project.Model
{
    public abstract class Course
    {
        public long Id { get; }
        public string Name { get; set; }
        public int Price { get; set; }
        public static float MinScore = 0.5f;

        public IDictionary<String, Mentor>? Mentors { get; set; }

        public Level Level { get; set; }
    }
}
