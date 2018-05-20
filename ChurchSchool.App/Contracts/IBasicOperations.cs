using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Application.Contracts
{
    public interface IBasicOperations<T>
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        T Add(T entity);
        bool Update(T entity);
        bool Remove(Guid id);
    }
}
