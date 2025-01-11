using BYT_Project.Model;
using System.ComponentModel.DataAnnotations;
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

    

    public static Course CourseAndTestAndMentor<A,B,C,D,E,F>(
            int numOfTests, DateTime createdAt, TimeSpan solvingTime, int numOfQuestions, string[] texts, string[] answers, List<string>[] posibleAnswers,
            A spec1, B spec2, C spec3, D spec4, E spec5, F spec6,
            string nameOfCourse, int price, DifficultyLevel level)
    {
        try
        {
            Course course = Course.CourseFactoryCreate(spec1, spec2, spec3, spec4, spec5, spec6, nameOfCourse, price, level);

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
