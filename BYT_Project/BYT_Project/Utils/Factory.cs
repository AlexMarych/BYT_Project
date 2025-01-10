using BYT_Project.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static BYT_Project.Model.Course;

public class Factory
{
    private static Test TestAndQuestions(DateTime createdAt, TimeSpan solvingTime, int numOfQuestions, string[] texts, string[] answers, List<string>[] posibleAnswers )
    {
        try
        {
            var test = Test.Create(createdAt, solvingTime);

            for (int i = 0; i < numOfQuestions; i++)
            {
                var question = Question.Create(texts[i], answers[i], posibleAnswers[i]);

                if (question == null) throw new ValidationException();

                test.AddQuestion(question);
                question.AddTest(test);
            }

            return test;
        } 
        catch (NullReferenceException) 
        {
            return null;
        } 
        catch (ValidationException)
        {
            return null;   
        }
    }

    private static void CourseAndMentor(Course course, string role, Mentor mentor,
        int salary, string experience, DateTime dateOfEmployment, string name, string surname, string email, DateTime dateOfBirth, string specialization)
    {
        if (mentor == null)
            mentor = Mentor.Create(salary, experience, dateOfEmployment, name, surname, email, dateOfBirth, specialization);

        course.AddMentor(role, mentor);
    }

    public static Course CourseAndTestAndMentor<A,B,C,D,E,F>(
            int numOfTests, DateTime createdAt, TimeSpan solvingTime, int numOfQuestions, string[] texts, string[] answers, List<string>[] posibleAnswers,
            A spec1, B spec2, C spec3, D spec4, E spec5, F spec6,
            string nameOfCourse, int price, DifficultyLevel level,
             string role, Mentor mentor,
        int salary, string experience, DateTime dateOfEmployment, string name, string surname, string email, DateTime dateOfBirth, string specialization)
    {
        try
        {
            Course course = Course.CourseFactoryCreate(spec1, spec2, spec3, spec4, spec5, spec6, nameOfCourse, price, level);

            CourseAndMentor(course,role, mentor, salary, experience, dateOfEmployment, name, surname, email, dateOfBirth, specialization);

            for (int i = 0; i < numOfTests; i++)
            {
                var test = TestAndQuestions(createdAt, solvingTime, numOfQuestions, texts, answers, posibleAnswers);

                if (test == null) throw new ValidationException();

                course.AddTest(test);
                test.AddCourse(course);
            }

            return course;
        }
        catch (NullReferenceException)
        {
            return null;
        }
        catch (ValidationException)
        {
            return null;
        }
    }

    

}
