using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchSchool.Repository
{
    public class StudentRepository : IRepository<Student>
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

        public IQueryable<Student> Filter(Student model)
        {
            return _repositoryContext.Students.Where(x => x == model);
        }

        public IQueryable<Student> GetAll()
        {
            return _repositoryContext.Students;
        }

        public bool Remove(Guid key)
        {
            try
            {
                var itemToRemove = _repositoryContext.Students.Find(key);

                _repositoryContext.Students.Remove(itemToRemove);

                _repositoryContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                //TODO ADD LOG HERE
                return false;
            }
        }

        public bool Update(Student model)
        {
            try
            {
                var itemToUpdate = _repositoryContext.Students.Find(model.Id);

                itemToUpdate = model;

                _repositoryContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                //TODO - ADD LOG HERE
                return false;
            }
        }
    }
}
