using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Repository.Repositories
{
    public class CourseConfigurationRepository : ICourseConfigurationRepository
    {
        private readonly RepositoryContext _context;

        public CourseConfigurationRepository(RepositoryContext context) => _context = context;       

        public CourseConfiguration Add(CourseConfiguration model)
        {
            _context.Configurations.Add(model);
            return model;
        }

        public IEnumerable<CourseConfiguration> Filter(CourseConfiguration model) => _context.Configurations.AsNoTracking().Where(x => x == model);

        public IEnumerable<CourseConfiguration> GetByCourse(long courseId) => GetBaseQuery().Where(x => Convert.ToInt64(x.CourseId) == courseId);

        public IEnumerable<CourseConfiguration> GetAll() => GetBaseQuery();

        public bool Remove(long key)
        {
            var itemToRemove = _context.Configurations.FirstOrDefault(x => x.Id == key);

            if (itemToRemove != null)
            {
                itemToRemove.RemovedDate = DateTime.Now;
                return true;
            }

            return false;

        }

        public bool Update(CourseConfiguration model)
        {
            return false;
        }

        public CourseConfiguration Get(long configurationId)
        {
            return _context.Configurations.AsNoTracking().FirstOrDefault(x => x.Id == configurationId);
        }

        public IEnumerable<CourseConfiguration> GetBaseQuery()
        {
            return _context.Configurations.AsNoTracking()
                                          .Include(x => x.EnrollDocuments)
                                          .AsNoTracking();
                                          
        }
    }
}
