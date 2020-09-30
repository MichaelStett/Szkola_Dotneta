using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;

using ToLearn.Entities;
using ToLearn.Enums;
using ToLearn.Extensions;
using ToLearn.Implemented;
using ToLearn.Interfaces;

using static System.Console;
using static System.Enum;

namespace ToLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                 .AddSingleton<IContext, Context>()
                 .AddSingleton<IService<MyTask>, TaskService>()
                 .AddSingleton<IRepository<MyTask>, Repository>()
                 .BuildServiceProvider();

            var service = serviceProvider.GetService<IService<MyTask>>();

            var menu = new List<string>()
            {
                "Show all entires",
                "Show all uncompleted tasks",
                "Show task from category",
                "Show specific task",
                "Mark task ask completed",
                "Create new task",
                "Update exising task",
                "Delete exising task"
            };

            do
            {
                foreach (var item in menu.WithIndex())
                {
                    WriteLine($"{item.index}. {item.value}.");
                }

                Write("Option: ");
                var input = ReadLine();

                int.TryParse(input, out int choice);

                switch (choice)
                {
                    case 0:
                        service.GetAll().WriteInLines();
                        break;
                    case 1:
                        service.GetAllNotCompleted().WriteInLines();
                        break;
                    case 2:
                        WriteLine("Choose category: ");

                        WriteCategories();

                        input = ReadLine();

                        try
                        {
                            TryParse(input, out CategoryType category);

                            service.GetAllFromCategory(category).WriteInLines();
                        }
                        catch { }

                        break;
                    case 3:
                        input = ReadLine();

                        try
                        {
                            TryParse(input, out int index);

                            var task = service.GetById(index);

                            WriteLine(task);
                        }
                        catch { }

                        break;
                    case 4:
                        input = ReadLine();

                        try
                        {
                            TryParse(input, out int index);

                            service.MarkAsCompleted(index);

                            WriteLine("Marked!");
                        }
                        catch { }

                        break;
                    case 5:
                        var newTask = new MyTask();

                        Write("Enter title"); newTask.Title = ReadLine();
                        Write("Enter description"); newTask.Description = ReadLine();

                        WriteCategories();

                        input = ReadLine();

                        try
                        {
                            TryParse(input, out CategoryType category);

                            newTask.Category = category;
                        }
                        catch { }

                        service.Create(newTask);

                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    default:
                        WriteLine("Wrong option.");
                        break;
                }
            } while (true);
        }

        internal static void WriteCategories()
        {
            Array values = GetValues(typeof(CategoryType));

            var idx = 1;
            foreach (var value in values)
            {
                string s = GetName(typeof(CategoryType), value);
                WriteLine($"{idx++}: {s}");
            }
        }
    }
}
