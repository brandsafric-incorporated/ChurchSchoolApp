using ChurchSchool.Application.Contracts;
using ChurchSchool.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Application
{
    public class Course : ICourse
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWorkIdentity _unitOfWork;

        public Course(
            ICourseRepository courseRepository,
            IUnitOfWorkIdentity unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public Domain.Entities.Course Add(Domain.Entities.Course course)
        {
            if (!course.IsValid())
            {
                return course;
            }

            if (_courseRepository.GetAll().Any(g => g.Name.Trim().ToLower() == course.Name.Trim().ToLower()))
            {
                course.AddError("Já existe um curso cadastrado com esse nome.");
                return course;
            }

            _courseRepository.Add(course);
            _unitOfWork.Commit();

            return course;
        }

        public IEnumerable<Domain.Entities.Course> Filter(string name)
        {
            return _courseRepository.Filter(new Domain.Entities.Course { Name = name });
        }

        public IEnumerable<Domain.Entities.Course> GetAll()
        {
            return _courseRepository.GetAll();
        }

        public Domain.Entities.Course GetById(long id)
        {
            var result = _courseRepository.Filter(new Domain.Entities.Course { Id = id })
                                          .FirstOrDefault();
            return result;
        }

        public bool Remove(long id)
        {
            var wasRemoved = _courseRepository.Remove(id);

            _unitOfWork.Commit();

            return wasRemoved;
        }

        public bool Update(Domain.Entities.Course course)
        {
            var wasUpdated = _courseRepository.Update(course);

            _unitOfWork.Commit();

            return wasUpdated;
        }
    }
}
