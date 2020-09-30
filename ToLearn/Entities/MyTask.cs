using System;
using System.Collections.Generic;
using System.Text;

using ToLearn.Enums;

namespace ToLearn.Entities
{
    public class MyTask : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public CategoryType Category { get; set; }
        public bool IsCompleted { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime? Completed { get; private set; }

        public MyTask(string title, string desc, CategoryType type)
            : base()
        {
            Title = title;
            Description = desc;
            Category = type;
        }

        public MyTask()
        {
            Created = DateTime.UtcNow;
        }

        public void CompleteTask()
        {
            IsCompleted = true;
            Completed = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"{Title} - {Category} - Completed<{IsCompleted}>: {Description}";
        }
    }
}
