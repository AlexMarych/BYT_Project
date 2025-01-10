using BYT_Project.Utils;
using BYT_Project.Utils.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BYT_Project.Model
{
    [Serializable]
    public abstract class Course
    {
        public long Id { get; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public enum DifficultyLevel
        {
            Beginner,
            Intermidiate,
            Advanced
        }

        public DifficultyLevel difficultyLevel { get; set; }

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        public List<Payment> Payments { get; set; }
        public IDictionary<string, Mentor>? Mentors { get; set; }

        public List<Test>? Tests { get; set; }
        private static int _staticId;

        protected Course(string name, int price, IDictionary<string, Mentor>? mentors, DifficultyLevel difficulty, List<Test>? tests)
        {
            Name = name;
            Price = price;
            Mentors = mentors;
            difficultyLevel = difficulty;
            Tests = tests;

            Id = ++_staticId;
        }

        public static Course? CourseFactoryCreate<A, B, C, D, E, F>(
            A spec1, B spec2, C spec3, D spec4, E spec5, F spec6,
            string name, int price, DifficultyLevel level)
        {
            
            if (spec1 is string technologyName && spec2 is List<string> frameworkList)
            {
                return CreateProgrammingCourse(spec3, spec4, spec5, spec6, technologyName, frameworkList, name, price, level);
            }
            
            else if (spec1 is string domainName && spec2 is Managment.Level managementLevel)
            {
                return CreateManagementCourse(spec3, spec4, spec5, spec6, domainName, managementLevel, name, price, level);
            }

            return null;
        }
        
        private static Course? CreateProgrammingCourse<C, D, E, F>(
            C spec3, D spec4, E spec5, F spec6,
            string technologyName, List<string> frameworkList,
            string name, int price, DifficultyLevel level)
        {
            if (spec3 is TimeSpan duration && spec4 is int videoCount)
            {
                return Video_Programming.Create(duration, videoCount, technologyName, frameworkList, name, price, level);
            }
            else if (spec3 is string textContent && spec4 is TimeSpan readingDuration)
            {
                if (spec5 is TimeSpan combinedDuration && spec6 is int combinedVideoCount)
                {
                    return TextAndVideo_Programming.Create(
                        textContent, readingDuration, combinedDuration, combinedVideoCount,
                        technologyName, frameworkList, name, price, level);
                }
                return Text_Programming.Create(textContent, readingDuration, technologyName, frameworkList, name, price, level);
            }

            return null;
        }

        
        private static Course? CreateManagementCourse<C, D, E, F>(
            C spec3, D spec4, E spec5, F spec6,
            string domainName, Managment.Level level,
            string name, int price, DifficultyLevel difficultyLevel)
        {
            if (spec3 is TimeSpan duration && spec4 is int videoCount)
            {
                return Video_Managment.Create(duration, videoCount, domainName, level, name, price, difficultyLevel);
            }
            else if (spec3 is string textContent && spec4 is TimeSpan readingDuration)
            {
                if (spec5 is TimeSpan combinedDuration && spec6 is int combinedVideoCount)
                {
                    return TextAndVideo_Managment.Create(
                        textContent, readingDuration, combinedDuration, combinedVideoCount,
                        domainName, level, name, price, difficultyLevel);
                }
                return Text_Managment.Create(textContent, readingDuration, domainName, level, name, price, difficultyLevel);
            }

            return null;
        }




        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Course course &&
                   Id == course.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public virtual bool AddMentor(string role, Mentor mentor)
        {
            Mentors ??= new Dictionary<string, Mentor>();
            mentor.Courses ??= [];

            if (mentor.Courses.Contains(this) || Mentors.ContainsKey(role))
                return false;

            Mentors.Add(role, mentor);
            mentor.AddCourse(this, role);

            return true;
        }

        public virtual bool AddPayment(Student student)
        {
            Payment pay = Payment.Create(student, this);

            Payments ??= [];
            student.Payments ??= [];

            if (Payments.Contains(pay) || student.Payments.Contains(pay))
                return false;

            Payments.Add(pay);
            student.AddPayment(this);

            return true;
        }

        public virtual bool AddTest(Test test)
        {
            Tests ??= new List<Test>();
            
            if (test.course == this || Tests.Contains(test))
                return false;

            Tests.Add(test);
            test.AddCourse(this);

            return true;

        }

    }
}