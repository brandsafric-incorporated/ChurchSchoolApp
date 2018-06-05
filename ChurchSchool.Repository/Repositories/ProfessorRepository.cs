using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChurchSchool.Domain.Enum;

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
            return _repositoryContext.Professors;
        }

        public bool Remove(Guid key)
        {

            var itemToRemove = _repositoryContext.Professors.Find(key);

            _repositoryContext.Professors.Remove(itemToRemove);            

            return true;
        }

        public bool Update(Professor model)
        {

            var itemToUpdate = _repositoryContext.Professors.Find(model.Id);

            itemToUpdate = model;           

            return true;

        }
    }   
}
