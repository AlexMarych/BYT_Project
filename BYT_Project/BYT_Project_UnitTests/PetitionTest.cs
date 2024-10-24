using BYT_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BYT_Project_UnitTests
{
    internal class PetitionTest
    {
        Petition petition = new Petition("petition", Petition.StatusType.Opened);

        [Test]
        public void PetitionDataValidationTest_Text()
        {
            Assert.IsInstanceOf<string>(petition.Text);
        }
        [Test]
        public void PetitionDataValidationTest_Status()
        {
            Assert.IsInstanceOf<Enum>(petition.Status);
        }
    }
}
