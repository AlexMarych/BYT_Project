using BYT_Project.Model;
using BYT_Project.Utils;

Console.WriteLine("Class extents");

List<Question> questions =
[
    new("Swofford?", "Sir yes sir!", ["ewew", "dadad"]),
            new("Swofford?", "Sir yes sir!", ["ewew", "dadad"]),
            new("Swofford?", "Sir yes sir!", ["ewew", "dadad"])
];

Test? test = Test.Create(new DateTime(2023, 09, 11), new TimeSpan(1, 30, 0), questions);

var testListBefore = Test._extent;
//var questionListBefore = ExtentManager.LoadExtent<Question>();

Console.WriteLine(testListBefore.Contains(test));


Test.Delete(test);

var testListAfter = Test._extent;
//var questionListAfter = ExtentManager.LoadExtent<Question>();


Console.WriteLine(!testListAfter.Contains(test));