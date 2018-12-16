using AutoMapper;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Application.Models;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Application
{
    public class Course : ICourse
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly ICourseConfigurationRepository _courseConfigurationRepository;

        public Course(ICourseRepository courseRepository, 
                      IMapper mapper,
                      ICourseConfigurationRepository courseConfigurationRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _courseConfigurationRepository = courseConfigurationRepository;
        }

        public Domain.Entities.Course Add(Domain.Entities.Course course)
        {
            return _courseRepository.Add(course);
        }

        public IEnumerable<Domain.Entities.Course> Filter(string name)
        {
            return _courseRepository.Filter(new Domain.Entities.Course { Name = name });
        }

        public IEnumerable<Domain.Entities.Course> Filter(Domain.Entities.Course course)
        {
            return _courseRepository.Filter(course);
        }

        public IEnumerable<Domain.Entities.Course> GetAll()
        {
            var result = _courseRepository.GetAll().ToList();

            return result;
        }

        public Domain.Entities.Course GetById(long id)
        {
            var result = _courseRepository.Filter(new Domain.Entities.Course { Id = id })
                                          .FirstOrDefault();
            return result;
        }

        public bool Remove(long id)
        {
            return _courseRepository.Remove(id);
        }

        public bool Update(Domain.Entities.Course course)
        {
            return _courseRepository.Update(course);
        }
    }
}
