using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        IList<Student> students = new List<Student>()
        {
            new Student(){Id = 1, Age = 18, Name = "John"},
            new Student(){Id = 2, Age = 21, Name = "Steve"},
            new Student(){Id = 3, Age = 18, Name = "Bill"},
            new Student(){Id = 4, Age = 20, Name = "Rom"},
            new Student(){Id = 5, Age = 21, Name = "Ron"}
        };

        // Using the LINQ query
        var teengerStudent = from s in students
                             where s.Age > 12 && s.Age < 20
                             select s;

        foreach (var student in teengerStudent)
        {
            Console.WriteLine(student.Name);
        }



        //returns the latest data. Deferred execution re-evaluates on each execution;
        //this is called lazy evaluation.
        students.Add(new Student() { Id = 6, Age = 16, Name = "Martin" });

        foreach (var student in teengerStudent)
        {
            Console.WriteLine(student.Name);
        }





        Console.WriteLine("---------------------------------------");



        // implement deferred execution for your custom extension methods
        // for IEnumerable using the yield keyword.

        IEnumerable<Student> teenAgerStudents = students.GetTeenAgerStudents();

        foreach (var student in teenAgerStudents)
        {
            Console.WriteLine(student.Name);
        }
    }
}

public static class StudentExtensions
{
    public static IEnumerable<Student> GetTeenAgerStudents(this IEnumerable<Student> source)
    {
        foreach (Student std in source)
        {
            Console.WriteLine("Accessing student {0}", std.Name);

            if (std.Age > 12 && std.Age < 20)
                yield return std;
        }
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
