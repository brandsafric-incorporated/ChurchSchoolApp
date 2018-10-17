using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChurchSchool.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using ChurchSchool.Repository.Contracts;

namespace ChurchSchool.Repository.Repositories
{
    
    public class ProfessorRepository : IProfessorRepository
    {
        private RepositoryContext _repositoryContext;

        public ProfessorRepository(IPersonRepository personRepository, RepositoryContext repositoryContext) 
        {
            _repositoryContext = repositoryContext;
        }

        public Professor Add(Professor model)
        {
            _repositoryContext.Professors.Add(model);           

            return model;
        }

        public IEnumerable<Professor> Filter(Professor model)
        {
            return _repositoryContext.Professors.Where(x => x == model);
        }

        public IEnumerable<Professor> GetAll()
        {
            return _repositoryContext.Professors.Include(e => e.Person)
                                                .ThenInclude(t => t.Addresses)
                                                .Include(e => e.Person)
                                                .ThenInclude(t => t.Documents)
                                                .Include(e => e.Person)
                                                .ThenInclude(t => t.Phones)
                                                .Include(t => t.RelatedSubjects)
                                                .ThenInclude(q => q.Subject);
        }

        public long GetAvaiableTeacherAmount()
        {
            return 0;
        }

        public bool Remove(Guid key)
        {

            var itemToRemove = _repositoryContext.Professors.FirstOrDefault(t => t.Id == key);

            if (itemToRemove == null)
                return false;

            itemToRemove.RemovedDate = DateTime.Now;

            Update(itemToRemove);

            return true;
        }

        public bool Update(Professor model)
        {

            model.UpdatedDate = DateTime.Now;

            _repositoryContext.Update(model);

            return true;

        }
    }   
}
