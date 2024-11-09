using BYT_Project.Model;
using BYT_Project.Utils;
using static BYT_Project.Model.Course;
using static BYT_Project.Model.Managment;

Console.WriteLine("Class extents");

Test test1 = new Test(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), new());

ExtentManager.ClearExtent<Test>();

Test test2 = new Test(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), new());