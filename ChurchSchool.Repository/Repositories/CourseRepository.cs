using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Repository.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbContext _context;

        public CourseRepository(IDbContext context) => _context = context;

        public Course Add(Course model)
        {
            _context.Courses.Add(model);
            return model;
        }

        public IEnumerable<Course> Filter(Course model) => _context.Courses.Where(x => x == model);

        public IEnumerable<Course> GetAll() => _context.Courses;

        public bool Remove(long key)
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