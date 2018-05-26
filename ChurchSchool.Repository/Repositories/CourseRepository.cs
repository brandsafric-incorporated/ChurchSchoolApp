using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private RepositoryContext _repositoryContext;

        public CourseRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Course Add(Course model)
        {
            _repositoryContext.Courses.Add(model);

            _repositoryContext.SaveChanges();

            return model;
        }

        public IEnumerable<Course> Filter(Course model)
        {
            return _repositoryContext.Courses.AsNoTracking().Where(x => x == model);
        }

        public IEnumerable<Course> GetAll()
        {
            return _repositoryContext.Courses.AsNoTracking();
        }

        public bool Remove(Guid key)
        {
            var itemToRemove = _repositoryContext.Courses.FirstOrDefault(y => y.Id == key);

            itemToRemove.RemovedDate = DateTime.Now;

            _repositoryContext.SaveChanges();

            return true;
        }

        public bool Update(Course model)
        {
            model.UpdatedDate = DateTime.Now;

            _repositoryContext.Courses.Update(model);

            _repositoryContext.SaveChanges();

            return true;
        }


    }
}
