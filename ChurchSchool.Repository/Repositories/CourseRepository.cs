using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using ChurchSchool.Repository.Contracts;

namespace ChurchSchool.Repository.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly RepositoryContext _context;

        public CourseRepository(RepositoryContext context) => _context = context;

        public Course Add(Course model)
        {
            _context.Courses.Add(model);
            return model;
        }

        public IEnumerable<Course> Filter(Course model) => _context.Courses.Where(x => x == model);

        public IEnumerable<Course> GetAll() => _context.Courses;

        public bool Remove(Guid key)
        {
            var itemToRemove = _context.Courses.FirstOrDefault(y => y.Id == key);

            itemToRemove.RemovedDate = DateTime.Now;

            return true;
        }

        public bool Update(Course model)
        {
            model.UpdatedDate = DateTime.Now;

            _context.Courses.Update(model);

            return true;
        }
    }
}