using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Repository.Repositories
{
    public class GradeHistoryRepository //: IGradeHistoryRepository
    {
        /*
        private RepositoryContext _repositoryContext;

        public GradeHistoryRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<GradeHistory> Add(GradeHistory model)
        {
            _repositoryContext.GradeHistory.Add(model);

            await _repositoryContext.SaveChangesAsync();

            return model;
        }

        public IEnumerable<GradeHistory> Filter(GradeHistory model)
        {
            return _repositoryContext.GradeHistory.Where(x => x == model);
        }

        public IEnumerable<GradeHistory> GetAll()
        {
            return _repositoryContext.GradeHistory;
        }

        public async Task<bool> Remove(Guid key)
        {

            var itemToRemove = await _repositoryContext.GradeHistory.FindAsync(key);

            _repositoryContext.GradeHistory.Remove(itemToRemove);

            _repositoryContext.SaveChanges();

            return true;
        }

        public async Task<bool> Update(GradeHistory model)
        {

            var itemToUpdate = await _repositoryContext.GradeHistory.FindAsync(model.Id);

            itemToUpdate = model;

            _repositoryContext.SaveChanges();

            return true;

        }
        */

    }
}
