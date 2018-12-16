using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Repository.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly RepositoryContext _context;

        private static readonly Func<Course, Course, bool> CourseFilter = (a, b) =>
                    ((a.Id == null || (a.Id != null && a.Id == b.Id)) &&
                     (string.IsNullOrEmpty(a.Name) || (!string.IsNullOrEmpty(a.Name) && a.Name == b.Name)) &&
                     (a.IsActive == null || (a.IsActive != null && a.IsActive == b.IsActive))
                    );

        public CourseRepository(RepositoryContext context) => _context = context;

        public Course Add(Course model)
        {
            _context.Courses.Add(model);
            return model;
        }

        public bool Remove(long key)
        {
            var itemToRemove = _context.Courses.FirstOrDefault(y => y.Id == key);

            itemToRemove.RemovedDate = DateTime.Now;

            return true;
        }

        public bool Update(Course model)
        {
            model.InsertedDate = _context.Courses.AsNoTracking().FirstOrDefault(x => x.Id == model.Id)?.InsertedDate;
            model.UpdatedDate = null;
            _context.Update(model);
            return true;
        }

        private IEnumerable<Course> GetBaseQuery()
        {
            var response = _context.Courses.Include(t => t.CurrentConfiguration)
                                           .ThenInclude(f => f.EnrollDocuments)
                                           .Include(q => q.CurrentConfiguration)
                                           .AsNoTracking()
                                           ;
            return response;
        }

        public IEnumerable<Course> Filter(Course model)
        {
            return (from course in _context.Courses
                    where (
                            (model.Id == null || (model.Id != null && model.Id == course.Id)) &&
                            (string.IsNullOrEmpty(model.Name) || (!string.IsNullOrEmpty(model.Name) && model.Name == course.Name)) &&
                            (model.IsActive == null || (model.IsActive != null && model.IsActive == course.IsActive))
                    )
                    select course).Include(t => t.CurrentConfiguration)
                                   .ThenInclude(f => f.EnrollDocuments)
                                   .Include(q => q.CurrentConfiguration)
                                   .AsNoTracking()
                    ;
        }

        public IEnumerable<Course> GetAll()
        {
            return GetBaseQuery();
        }
    }
}