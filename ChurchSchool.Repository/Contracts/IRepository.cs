using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchSchool.Repository.Contracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Filter(T model);
        T Add(T model);
        bool Update(T model);
        bool Remove(Guid key);
    }
}
