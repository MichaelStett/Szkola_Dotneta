using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Exercise
{
    public class Program
    {
        public static void Main()
        {
            var people = new List<Person>()
            {
                new Person("Marek", "Marecki", 41),
                new Person("Wojtek", "Wojciechowski", 22),
                new Person("Maciej", "Maciejewski", 21),
                new Person("Kajetan","Kajetanowicz", 19 ),
                new Person("Darek","Darecki", 49 ),
                new Person("Michał","Michałowski", 51 ),
                new Person("Grzegorz","Grzegorzewski", 19),
                new Person("Andrzej","Andrzejewski", 18),
                new Person("Marcin","Marcinkiewicz", 58 ),
                new Person("Jan","Janowski", 58),
                new Person("Paweł","Pawelski", 84 ),
                new Person("Zbigniew","Hołdys", 19 ),
            };

            //Napisz LINQ które zwróci osoby których nazwisko rozpoczyna się na literę M
            var selected = people.Select(p => p.LastName[0] is 'M');

            Console.WriteLine("Ilość osób których nazwisko rozpoczyna się na literę M wynosi:  " + selected.Count());

            //Napisz LINQ które zwróci pierwszą osobę starszą niż 40 lat ze zbioru posegregowanego odwrotnie alfabetycznie (Z -> A) wg. imienia
            var person = people.OrderByDescending(p => p.FirstName)
                               .Where(p => p.Age > 40)
                               .First();

            Console.WriteLine("Pierwsza osoba powyżej 40 lat to: " + person.ToString());
        }

        public class Person
        {
            public Person(string firstName, string lastName, int age)
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }

            //nadpisz metodę ToString() dla klasy Person która będzie zwracać Imię.
            public override string ToString()
            {
                return $"{FirstName}";
            }
        }
    }
}
