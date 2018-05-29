using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private RepositoryContext _repositoryContext;

        public StudentRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Student Add(Student model)
        {
            _repositoryContext.Students.Add(model);

            _repositoryContext.SaveChanges();

            return model;
        }

        public IEnumerable<Student> Filter(Student model)
        {
            return _repositoryContext.Students.AsNoTracking().Where(x => x == model);
        }

        public IEnumerable<Student> GetAll()
        {
            return _repositoryContext.Students.AsNoTracking();
        }

        public bool Remove(Guid key)
        {
            var itemToRemove = _repositoryContext.Students.Find(key);

            _repositoryContext.Students.Remove(itemToRemove);

            _repositoryContext.SaveChanges();

            return true;
        }

        public bool Update(Student model)
        {
            _repositoryContext.Update(model);

            _repositoryContext.SaveChanges();

            return true;

        }
    }
}
