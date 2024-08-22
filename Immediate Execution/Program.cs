internal class Program
{
    private static void Main(string[] args)
    {
        //Immediate execution is the reverse of deferred execution.

        IList<Student> students = new List<Student>()
        {
            new Student(){Id = 1, Age = 18, Name = "John"},
            new Student(){Id = 2, Age = 21, Name = "Steve"},
            new Student(){Id = 3, Age = 18, Name = "Bill"},
            new Student(){Id = 4, Age = 20, Name = "Rom"},
            new Student(){Id = 5, Age = 21, Name = "Ron"}
        };

        // Immediate Execution
        Console.WriteLine("Immediate Execution");
        IList<Student> teenAgerStudents =
                students.Where(s => s.Age > 12 && s.Age < 20).ToList();
        foreach (Student student in teenAgerStudents) 
        { Console.WriteLine(student.Name); }


        //Query Syntax
        Console.WriteLine("Query Syntax");
        IList<Student> teenAgerStudents2 = (from s in students
                                          where s.Age > 12 && s.Age < 20
                                          select s).ToList();

        foreach (Student student in teenAgerStudents2)
        { Console.WriteLine(student.Name); }

    }


    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}