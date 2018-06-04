using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChurchSchool.Domain.Contracts
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll ();
        IEnumerable<T> Filter(T model);
        T Add(T model);
        bool Update(T model);
        bool Remove(Guid key);
    }
}
