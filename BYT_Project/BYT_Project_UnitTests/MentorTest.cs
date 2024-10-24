using BYT_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYT_Project_UnitTests
{
    internal class MentorTest
    {
        Mentor mentor = new Mentor(1000, "Senior", new DateTime(2021, 06, 21), "Mike", "Wazowski",
        new DateTime(1989, 06, 11), new DateTime(2021, 06, 22), "spec");

        [Test]
        public void MentorDataValidationTest_Specialization()
        {
            Assert.IsInstanceOf<string>(mentor.Specialization);
        }
    }
}
