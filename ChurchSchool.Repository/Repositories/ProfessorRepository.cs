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
    /*
    public class ProfessorRepository : PersonBaseRepository, IProfessorRepository
    {
        private RepositoryContext _repositoryContext;

        public ProfessorRepository(IPersonRepository personRepository, RepositoryContext repositoryContext) : base(personRepository, repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<Professor> Add(Professor model)
        {
            _repositoryContext.Professors.Add(model);

            await _repositoryContext.SaveChangesAsync();

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

        public async Task<bool> Remove(Guid key)
        {

            var itemToRemove = await _repositoryContext.Professors.FindAsync(key);

            _repositoryContext.Professors.Remove(itemToRemove);

            _repositoryContext.SaveChanges();

            return true;
        }

        public async Task<bool> Update(Professor model)
        {

            var itemToUpdate = await _repositoryContext.Professors.FindAsync(model.Id);

            itemToUpdate = model;

            _repositoryContext.SaveChanges();

            return true;

        }

        public Person FindbyDocument(Document document)
        {
            return base.FindByDocument(document, ERole.PROFESSOR);
        }
    }

    */
}
