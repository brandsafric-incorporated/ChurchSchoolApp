using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChurchSchool.Repository.Contracts
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Filter(T model);
        Task<T> Add(T model);
        Task<bool> Update(T model);
        Task<bool> Remove(Guid key);
    }
}
