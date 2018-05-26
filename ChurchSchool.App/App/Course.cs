using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Application
{
    public class Course : ICourse
    {
        private readonly ICourseRepository _courseRepository;

        public Course(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Domain.Entities.Course Add(Domain.Entities.Course course)
        {
            return _courseRepository.Add(course);
        }

        public IEnumerable<Domain.Entities.Course> Filter(string name)
        {
            return _courseRepository.Filter(new Domain.Entities.Course { Name = name });
        }

        public IEnumerable<Domain.Entities.Course> GetAll()
        {
            return _courseRepository.GetAll();
        }

        public Domain.Entities.Course GetById(Guid id)
        {
            var result = _courseRepository.Filter(new Domain.Entities.Course { Id = id })
                                          .FirstOrDefault();
            return result;
        }

        public bool Remove(Guid id)
        {
            return _courseRepository.Remove(id);
        }

        public bool Update(Domain.Entities.Course course)
        {
            return _courseRepository.Update(course);
        }
    }
}
