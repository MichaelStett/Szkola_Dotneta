using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

using static System.Console;

namespace Linq_Pagination
{
    public class Program
    {
        public static List<T> Paginate<T>(List<T> students, int count, int page)
        {
            return students.Skip((page - 1) * count)
                           .Take(count)
                           .ToList();
        }

        static void Main(string[] args)
        {
            var fields = new string[]
            {
                "Economics", "Physics", "Chemistry", "Computer Science", "Astronomy"
            };

            var testStudents = new Faker<Student>()
                .RuleFor(s => s.Id, f => f.IndexGlobal)
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                .RuleFor(s => s.LastName, f => f.Name.LastName())
                .RuleFor(s => s.Age, f => f.Random.Number(19, 35))
                .RuleFor(s => s.Term, f => f.Random.Number(1, 7))
                .RuleFor(s => s.Field, f => f.PickRandom(fields));

            var students = testStudents.Generate(100);

            var selected = Paginate(students, 13, 4);

            foreach (var student in selected)
            {
                WriteLine(student);
            }
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Term { get; set; }
        public string Field { get; set; }

        public Student() { }

        public Student(string firstName, string lastName, int age, int term, string field)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Term = term;
            Field = field;
        }

        public override string ToString()
        {
            return $"{Id}: {FirstName} {LastName} {Age} {Term} {Field}";
        }
    }
}
