using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ToLearn.Entities;
using ToLearn.Interfaces;

namespace ToLearn.Implemented
{
    public class Repository : IRepository<MyTask>
    {
        private readonly IContext _context;

        public Repository(IContext context)
        {
            _context = context;
        }

        public virtual MyTask GetById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public virtual IEnumerable<MyTask> List()
        {
            return _context.Tasks.AsEnumerable();
        }

        public virtual IEnumerable<MyTask> List(Expression<Func<MyTask, bool>> predicate)
        {
            return _context.Tasks
                   .Where(predicate)
                   .AsEnumerable();
        }

        public void Insert(MyTask entity)
        {
            _context.Tasks.Add(entity);
            _context.SaveChangesAsync();
        }

        public void Update(MyTask entity)
        {
            _context.Tasks.Update(entity);
            _context.SaveChangesAsync();
        }

        public void Delete(MyTask entity)
        {
            _context.Tasks.Remove(entity);
            _context.SaveChangesAsync();
        }
    }
}
