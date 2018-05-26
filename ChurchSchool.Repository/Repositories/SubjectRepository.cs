using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private RepositoryContext _repositoryContext;

        public SubjectRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Subject Add(Subject model)
        {
            _repositoryContext.Subjects.Add(model);

            _repositoryContext.SaveChanges();

            return model;
        }

        public IEnumerable<Subject> Filter(Subject model)
        {
            return _repositoryContext.Subjects.AsNoTracking().Where(x => x.Id == model.Id);
        }

        public IEnumerable<Subject> GetAll()
        {
            return _repositoryContext.Subjects;
        }

        public bool Remove(Guid key)
        {
            var itemToRemove = _repositoryContext.Subjects.AsNoTracking().FirstOrDefault(x => x.Id == key);

            if (itemToRemove != null)
            {
                _repositoryContext.Subjects.Remove(itemToRemove);

                _repositoryContext.SaveChanges();

                return true;
            }

            return false;
        }

        public bool Update(Subject model)
        {
            var itemToUpdate = _repositoryContext.Subjects.AsNoTracking().FirstOrDefault(x => x.Id == model.Id);

            if (itemToUpdate != null)
            {
                itemToUpdate = model;

                _repositoryContext.Update(itemToUpdate);
                _repositoryContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
