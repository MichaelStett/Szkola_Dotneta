using System;
using System.Collections.Generic;
using System.Text;

using ToLearn.Enums;

namespace ToLearn.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> GetAllFromCategory(CategoryType category);
        IEnumerable<T> GetAllNotCompleted();
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);

        void MarkAsCompleted(int id);
    }
}
