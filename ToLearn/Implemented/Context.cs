using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

using ToLearn.Entities;
using ToLearn.Interfaces;

namespace ToLearn.Implemented
{
    public class Context : DbContext, IContext
    {
        public DbSet<MyTask> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Context;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public async void SaveChangesAsync()
        {
            base.SaveChanges();
        }
    }
}
