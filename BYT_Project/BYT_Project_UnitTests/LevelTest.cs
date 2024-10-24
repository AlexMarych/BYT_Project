using BYT_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYT_Project_UnitTests
{
    internal class LevelTest
    {
        Level level = new Level(Level.Name.Advanced);

        [Test]
        public void LevelDataValidationTest_Name()
        {
            Assert.IsInstanceOf<Enum>(level.name);
        }
    }
}
