using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Repository.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private RepositoryContext _repositoryContext;

        public SubjectRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<Subject> Add(Subject model)
        {
            _repositoryContext.Subjects.Add(model);

            await _repositoryContext.SaveChangesAsync();

            return model;
        }

        public IEnumerable<Subject> Filter(Subject model)
        {
            return _repositoryContext.Subjects.Where(x => x == model);
        }

        public IEnumerable<Subject> GetAll()
        {
            return _repositoryContext.Subjects;
        }

        public async Task<bool> Remove(Guid key)
        {

            var itemToRemove = await _repositoryContext.Subjects.FindAsync(key);

            _repositoryContext.Subjects.Remove(itemToRemove);

            _repositoryContext.SaveChanges();

            return true;
        }

        public async Task<bool> Update(Subject model)
        {

            var itemToUpdate = await _repositoryContext.Subjects.FindAsync(model.Id);

            itemToUpdate = model;

            _repositoryContext.SaveChanges();

            return true;

        }


    }
}
