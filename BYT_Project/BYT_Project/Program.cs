using BYT_Project.Model;
using BYT_Project.Utils;

var student1 = Student.Create("1", "Wazowski", "dwag@gmail.com", new DateTime(2003, 07, 21));
Person.ChangeState(student1, typeof(Mentor), 10000, "mid", "spec");

var student2 = Student.Create("2", "Wazowski", "dwag@gmail.com", new DateTime(2003, 07, 21));
Person.ChangeState(student2, typeof(Support), 1000, "mid", null);

var support1 = Support.Create(1000, "mid", DateTime.Now ,"3", "Wazowski", "dwag@gmail.com", new DateTime(2003, 07, 21));
Person.ChangeState(support1, typeof(Student), null);


var support2 = Support.Create(1000, "mid", DateTime.Now ,"4", "Wazowski", "dwag@gmail.com", new DateTime(2003, 07, 21));
Person.ChangeState(support2, typeof(Mentor), "spec");


var mentor1 = Mentor.Create(1000, "mid", DateTime.Now, "5", "Wazowski", "dwag@gmail.com", new DateTime(2003, 07, 21), "spec");
Person.ChangeState(mentor1, typeof(Student));


var mentor2 = Mentor.Create(1000, "mid", DateTime.Now, "6", "Wazowski", "dwag@gmail.com", new DateTime(2003, 07, 21), "spec");
Person.ChangeState(mentor2, typeof(Support));

