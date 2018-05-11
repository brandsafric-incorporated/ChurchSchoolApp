using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Repository.Repositories
{
    public class CourseConfigurationRepository : ICourseConfigurationRepository
    {
        private RepositoryContext _repositoryContext;

        public CourseConfigurationRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<CourseConfiguration> Add(CourseConfiguration model)
        {
            _repositoryContext.Configurations.Add(model);

            await _repositoryContext.SaveChangesAsync();

            return model;
        }

        public IEnumerable<CourseConfiguration> Filter(CourseConfiguration model)
        {
            return _repositoryContext.Configurations.Where(x => x == model);
        }

        public IEnumerable<CourseConfiguration> GetAll()
        {
            return _repositoryContext.Configurations;
        }

        public async Task<bool> Remove(Guid key)
        {

            var itemToRemove = await _repositoryContext.Configurations.FindAsync(key);

            _repositoryContext.Configurations.Remove(itemToRemove);

            _repositoryContext.SaveChanges();

            return true;
        }

        public async Task<bool> Update(CourseConfiguration model)
        {

            var itemToUpdate = await _repositoryContext.Configurations.FindAsync(model.Id);

            itemToUpdate = model;

            _repositoryContext.SaveChanges();

            return true;

        }


    }
}
