using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ChurchSchool.Repository.Contracts;

namespace ChurchSchool.Repository.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private RepositoryContext _context;

        public SubjectRepository(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public Subject Add(Subject model)
        {
            _context.Subjects.Add(model);

            return model;
        }

        public IEnumerable<Subject> Filter(Subject model)
        {
            return _context.Subjects.Where(x => x.Id == model.Id);
        }

        public IEnumerable<Subject> GetAll()
        {
            return _context.Subjects;
        }

        public bool Remove(long key)
        {
            var itemToRemove = _context.Subjects.FirstOrDefault(x => x.Id == key);

            if (itemToRemove != null)
            {
                _context.Subjects.Remove(itemToRemove);

                return true;
            }

            return false;
        }

        public bool Update(Subject model)
        {
            var itemToUpdate = _context.Subjects.AsNoTracking().FirstOrDefault(x => x.Id == model.Id);

            if (itemToUpdate != null)
            {
                itemToUpdate = model;

                _context.Update(itemToUpdate);

                return true;
            }

            return false;
        }        
    }
}
