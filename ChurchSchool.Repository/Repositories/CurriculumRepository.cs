using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Repository.Repositories
{
    public class CurriculumRepository : ICurriculumRepository
    {
        private RepositoryContext _repositoryContext;

        public CurriculumRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<Curriculum> Add(Curriculum model)
        {
            _repositoryContext.Curriculums.Add(model);

            await _repositoryContext.SaveChangesAsync();

            return model;
        }

        public IEnumerable<Curriculum> Filter(Curriculum model)
        {
            return _repositoryContext.Curriculums.Where(x => x == model);
        }

        public IEnumerable<Curriculum> GetAll()
        {
            return _repositoryContext.Curriculums;
        }

        public async Task<bool> Remove(Guid key)
        {

            var itemToRemove = await _repositoryContext.Students.FindAsync(key);

            _repositoryContext.Students.Remove(itemToRemove);

            _repositoryContext.SaveChanges();

            return true;
        }

        public async Task<bool> Update(Curriculum model)
        {

            var itemToUpdate = await _repositoryContext.Curriculums.FindAsync(model.Id);

            itemToUpdate = model;

            _repositoryContext.SaveChanges();

            return true;

        }


    }
}
