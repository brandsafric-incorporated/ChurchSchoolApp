using ChurchSchool.Domain.Entities;
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
        ValidationResult Update(T entity);
        ValidationResult Remove(Guid id);
    }
}
