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
    public class FrequencyRepository : IFrequencyRepository
    {
        
        private RepositoryContext _repositoryContext;

        public FrequencyRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<Frequency> Add(Frequency model)
        {
            _repositoryContext.Frequencies.Add(model);

            await _repositoryContext.SaveChangesAsync();

            return model;
        }

        public IEnumerable<Frequency> Filter(Frequency model)
        {
            return _repositoryContext.Frequencies.Where(x => x == model);
        }

        public IEnumerable<Frequency> GetAll()
        {
            return _repositoryContext.Frequencies;
        }

        public async Task<bool> Remove(Guid key)
        {

            var itemToRemove = await _repositoryContext.Frequencies.FindAsync(key);

            _repositoryContext.Frequencies.Remove(itemToRemove);

            _repositoryContext.SaveChanges();

            return true;
        }

        public async Task<bool> Update(Frequency model)
        {

            var itemToUpdate = await _repositoryContext.Frequencies.FindAsync(model.Id);

            itemToUpdate = model;

            _repositoryContext.SaveChanges();

            return true;

        }
    }
    */
}
