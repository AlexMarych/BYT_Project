using BYT_Project.Utils;
using BYT_Project.Utils.Exceptions;
using BYT_Project.Utils.Validation;
using System.ComponentModel.DataAnnotations;

namespace BYT_Project.Model
{
    public class Student : Person
    {
        [Range(0, int.MaxValue)]
        public int Balance { get; set; }

        [Range(0, 5)]
        public int Gpa { get; }
        public List<Petition>? Petitions { get; set; }
        public List<Payment>? Payments { get; set; }
        public List<StudentTest>? StudentTests { get; set; }
        private static List<Student> _extent = [];

        static Student()
        {
            _extent = ExtentManager.LoadExtent<Student>();
        }

        public Student(string name, string surname, string email, DateTime dateOfBirth, DateTime createdAt, int balance, List<StudentTest> studentTests) : base(name, surname, email, dateOfBirth, createdAt)
        {
            Balance = balance;
            StudentTests = studentTests;
            Gpa = StudentTests != null && StudentTests.Count != 0 ? StudentTests.Sum(x => x.Grade) / StudentTests.Count : 0;

            CustomValidator.Validate(this);

            _extent.Add(this);
            ExtentManager.ClearExtent<Student>();
            ExtentManager.SaveExtent(_extent);
        }

        public bool AssignPetition(Petition petition)
        {
            Petitions ??= [];

            if (petition.Student == this || Petitions.Contains(petition))
                return false;

            Petitions.Add(petition);
            petition.AddStudent(this);

            ExtentManager.ClearExtent<Student>();
            ExtentManager.SaveExtent(_extent);

            return true;
        }

        public static Student? Create(string name, string surname, string email, DateTime dateOfBirth, int balance)
        {
            try
            {
                return new Student(name,surname,email,dateOfBirth,DateTime.Now,balance, null);
            }
            catch
            {
                return null;
            }
        }

        public static void Modifiy(Student student)
        {

            Student modifiyable = _extent.First(x => x.Id == student.Id);

            _extent.Remove(modifiyable);
            _extent.Add(student);

            ExtentManager.ClearExtent<Student>();
            ExtentManager.SaveExtent(_extent);
        }

        public static void Delete(Student student)
        {
            _extent.Remove(student);
            ExtentManager.ClearExtent<Student>();
            ExtentManager.SaveExtent(_extent);
        }

        public override string ToString()
        {
            return base.ToString() + $" Balance: {Balance}, Gpa: {Gpa}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Student student &&
                   Id == student.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public bool AddPayment(Course course)
        {
            Payment pay = Payment.Create(this, course);

            StudentTests ??= [];

            if (course.Payments.Contains(pay) || Payments.Contains(pay))
                return false;

            Payments.Add(pay);
            course.AddPayment(this);
            ExtentManager.ClearExtent<Student>();
            ExtentManager.SaveExtent(_extent);

            return true;
        }

        public bool AddStudentTest(Test test, int grade)
        {
            StudentTest studentTest = StudentTest.Create(this, test, grade);

            Payments ??= [];

            if (test.StudentTests.Contains(studentTest) || StudentTests.Contains(studentTest))
                return false;

            StudentTests.Add(studentTest);
            test.AddStudentTest(this, grade);
            ExtentManager.ClearExtent<Student>();
            ExtentManager.SaveExtent(_extent);

            return true;
        }
    }
}