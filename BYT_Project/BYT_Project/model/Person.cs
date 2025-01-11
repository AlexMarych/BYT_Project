using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace BYT_Project.Model
{
    [Serializable]
    public abstract class Person
    {
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        private static int _staticId;

        protected Person(string name, string surname, string email, DateTime dateOfBirth, DateTime createdAt)
        {
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
            CreatedAt = createdAt;

            Id = ++_staticId;
        }


        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Surname: {Surname}, DateOfBirth: {DateOfBirth.ToString("yyyy-MM-dd")}, CreatedAt: {CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   Id == person.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static void ChangeState(Student student, Type type, int salary, string expirience, string? specialization) 
        {
            var method = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            var result = method.Invoke(null,  parameters: [salary, expirience, DateTime.Now ,student.Name, student.Surname, student.Email, student.DateOfBirth, specialization]);
            Student.Delete(student);
        }

        public static void ChangeState(Mentor mentor, Type type)
        {
            var method = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            if (type == typeof(Student))
                method.Invoke(null, parameters: [mentor.Name, mentor.Surname, mentor.Email, mentor.DateOfBirth, DateTime.Now]);
            else if (type == typeof(Support))
                method.Invoke(null, parameters: [mentor.Salary, mentor.Experience, mentor.Name, mentor.Surname, mentor.Email, mentor.DateOfBirth, DateTime.Now]);
            Mentor.Delete(mentor);
        }

        public static void ChangeState(Support support, Type type, string specialization)
        {
            var method = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            if (type == typeof(Mentor))
                method.Invoke(null, parameters: [support.Salary, support.Experience, support.Name, support.Surname, support.Email, support.DateOfBirth, DateTime.Now, specialization]);
            else if (type == typeof(Student))
                method.Invoke(null, parameters: [support.Name, support.Surname, support.Email, support.DateOfBirth, DateTime.Now]);
            Support.Delete(support);
        }
    }
}