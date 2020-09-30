using System;
using System.Collections.Generic;
using System.Text;

using ToLearn.Entities;
using ToLearn.Enums;
using ToLearn.Interfaces;

namespace ToLearn.Implemented
{
    public class TaskService : IService<MyTask>
    {
        private readonly IRepository<MyTask> _repo;

        public TaskService(IRepository<MyTask> repo)
        {
            _repo = repo;
        }

        public IEnumerable<MyTask> GetAll()
        {
            return _repo.List();
        }

        public IEnumerable<MyTask> GetAllFromCategory(CategoryType category)
        {
            return _repo.List(x => x.Category == category);
        }

        public IEnumerable<MyTask> GetAllNotCompleted()
        {
            return _repo.List(x => x.IsCompleted == false);
        }

        public MyTask GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Create(MyTask obj)
        {
            _repo.Insert(obj);
        }

        public void Update(MyTask obj)
        {
            _repo.Update(obj);
        }

        public void Delete(MyTask obj)
        {
            _repo.Delete(obj);
        }

        public void MarkAsCompleted(int id)
        {
           var task = _repo.GetById(id);

            task.CompleteTask();

            _repo.Update(task);
        }
    }
}
