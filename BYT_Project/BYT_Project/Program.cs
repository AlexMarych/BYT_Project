using BYT_Project.Model;
using BYT_Project.Utils;

var student = Student.Create("Maike", "Wazowski", "dwag@gmail.com", new DateTime(2003, 07, 21));
Person.ChangeState(student, typeof(Mentor), 10000, "mid", "spec");
ExtentManager.ReadExtent<Mentor>();

