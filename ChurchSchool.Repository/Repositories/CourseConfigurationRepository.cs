using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Repository.Repositories
{
    public class CourseConfigurationRepository : ICourseConfigurationRepository
    {
        private RepositoryContext _repositoryContext;

        public CourseConfigurationRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public CourseConfiguration Add(CourseConfiguration model)
        {
            _repositoryContext.Configurations.Add(model);

            _repositoryContext.SaveChangesAsync();

            return model;
        }

        public IEnumerable<CourseConfiguration> Filter(CourseConfiguration model)
        {
            return _repositoryContext.Configurations.AsNoTracking().Where(x => x == model);
        }

        public IEnumerable<CourseConfiguration> GetByCourse(Guid courseId)
        {
            return _repositoryContext.Configurations.AsNoTracking().Where(x => x.CourseId == courseId);
        }

        public IEnumerable<CourseConfiguration> GetAll()
        {
            return _repositoryContext.Configurations.AsNoTracking();
        }

        public bool Remove(Guid key)
        {

            var itemToRemove = _repositoryContext.Configurations.FirstOrDefault(x => x.Id == key);

            if (itemToRemove != null)
            {
                itemToRemove.RemovedDate = DateTime.Now;

                _repositoryContext.SaveChanges();

                return true;
            }

            return false;
        }

        public bool Update(CourseConfiguration model)
        {
            if (model.IsCurrentConfiguration)
            {
                foreach (var item in _repositoryContext.Configurations.Where(r => r.CourseId == model.CourseId))
                {
                    item.IsCurrentConfiguration = false;
                }
            }

            _repositoryContext.Update(model);

            _repositoryContext.SaveChanges();

            return true;
        }
    }
}
