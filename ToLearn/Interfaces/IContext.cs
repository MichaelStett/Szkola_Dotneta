using Microsoft.EntityFrameworkCore;

using ToLearn.Entities;

namespace ToLearn.Interfaces
{
    public interface IContext
    {
        DbSet<MyTask> Tasks { get; set; }

        void SaveChangesAsync();
    }
}