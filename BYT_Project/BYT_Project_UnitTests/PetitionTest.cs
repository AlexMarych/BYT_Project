using BYT_Project.Model;
using BYT_Project.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static BYT_Project.Model.Course;
using static BYT_Project.Model.Managment;

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
        [Test]
        public void PetitionEmptySringValidationTest_Text()
        {
            Assert.Throws<ValidationException>(() => CutsomValidator.Validate(
                new Petition("", Petition.StatusType.Opened)));
        }
    }
}
