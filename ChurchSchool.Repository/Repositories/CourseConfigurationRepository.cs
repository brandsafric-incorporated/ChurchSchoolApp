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

        public CourseConfigurationRepository(RepositoryContext context)
        {
            _context = context;
        }

        public CourseConfiguration Add(CourseConfiguration model)
        {
            _context.Configurations.Add(model);
            return model;
        }

        public IEnumerable<CourseConfiguration> Filter(CourseConfiguration model) => _context.Configurations.Where(x => x == model);

        public IEnumerable<CourseConfiguration> GetByCourse(Guid courseId) => _context.Configurations.Where(x => x.CourseId == courseId);

        public IEnumerable<CourseConfiguration> GetAll() => _context.Configurations;

        public bool Remove(Guid key)
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
            if (model.IsCurrentConfiguration)
            {
                foreach (var item in GetByCourse(model.CourseId))
                {
                    item.IsCurrentConfiguration = false;
                }
            }

            _context.Update(model);
            return true;
        }
    }
}
