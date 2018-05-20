using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Application.App
{
    public class CourseConfiguration : ICourseConfiguration
    {
        private ICourseConfigurationRepository _courseConfigurationRepository;

        public CourseConfiguration(ICourseConfigurationRepository courseConfigurationRepository)
        {
            _courseConfigurationRepository = courseConfigurationRepository;
        }

        public IEnumerable<Domain.Entities.CourseConfiguration> GetAll()
        {
            return _courseConfigurationRepository.GetAll();
        }

        public Domain.Entities.CourseConfiguration Add(Domain.Entities.CourseConfiguration entity)
        {
            return _courseConfigurationRepository.Add(entity);
        }

        public Domain.Entities.CourseConfiguration GetById(Guid id)
        {
            return _courseConfigurationRepository.Filter(new Domain.Entities.CourseConfiguration { Id = id })
                                                 .FirstOrDefault();

        }

        public IEnumerable<Domain.Entities.CourseConfiguration> GetByCourse(Guid courseId)
        {
            return _courseConfigurationRepository.Filter(new Domain.Entities.CourseConfiguration { CourseId = courseId });
        }

        public bool Remove(Guid id)
        {
            return _courseConfigurationRepository.Remove(id);
        }

        public bool Update(Domain.Entities.CourseConfiguration entity)
        {
            return _courseConfigurationRepository.Update(entity);
        }
    }
}
