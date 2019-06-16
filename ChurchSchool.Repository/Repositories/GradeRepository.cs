using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Repository.Repositories
{
    /*
    public class GradeRepository : IGradeRepository
    {
        private RepositoryContext _repositoryContext;

        public GradeRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<Grade> Add(Grade model)
        {
            _repositoryContext.Grades.Add(model);

            await _repositoryContext.SaveChangesAsync();

            return model;
        }

        public IEnumerable<Grade> Filter(Grade model)
        {
            return _repositoryContext.Grades.Where(x => x == model);
        }

        public IEnumerable<Grade> GetAll()
        {
            return _repositoryContext.Grades;
        }

        public async Task<bool> Remove(long key)
        {

            var itemToRemove = await _repositoryContext.Grades.FindAsync(key);

            _repositoryContext.Grades.Remove(itemToRemove);

            _repositoryContext.SaveChanges();

            return true;
        }

        public async Task<bool> Update(Grade model)
        {

            var itemToUpdate = await _repositoryContext.Grades.FindAsync(model.Id);

            itemToUpdate = model;

            _repositoryContext.SaveChanges();

            return true;

        }
    }
    */
}
