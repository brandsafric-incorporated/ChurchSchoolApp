using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Repository.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly RepositoryContext _context;

        private static readonly Func<Course, Course, bool> CourseFilter = (a, b) =>
                    ((a.Id != null && a.Id == b.Id) || (!string.IsNullOrEmpty(a.Name) && a.Name == b.Name));

        public CourseRepository(RepositoryContext context) => _context = context;

        public Course Add(Course model)
        {
            _context.Courses.Add(model);
            return model;
        }

        public IEnumerable<Course> Filter(Course model)
        {
            return this.GetBaseQuery()
                       .AsNoTracking()
                       .Where(x => CourseFilter(x, model));
        }

        public IEnumerable<Course> GetActiveCourses()
        {
            return this.GetBaseQuery()
                            .AsNoTracking()
                            .Where(c => c.IsActive)
                            ;
        }

        public IEnumerable<Course> GetAll() => this.GetBaseQuery().AsNoTracking();

        public bool Remove(Guid key)
        {
            var itemToRemove = _context.Courses.FirstOrDefault(y => y.Id == key);

            itemToRemove.RemovedDate = DateTime.Now;

            return true;
        }

        public bool Update(Course model)
        {
            var course = model;
            var configuration = model.CurrentConfiguration;
            var subjects = model.CurrentConfiguration.Subjects;
            var documents = model.CurrentConfiguration.EnrollDocuments;

            course.CurrentConfiguration = null;

            course.UpdatedDate = DateTime.Now;

            _context.Entry(course).State = EntityState.Modified;
            _context.Entry(configuration).State = EntityState.Modified;


            if (subjects != null)
                foreach (var item in subjects)
                {
                    _context.Entry(item).State = EntityState.Modified;
                }

            if (documents != null)
                foreach (var item in documents)
                {
                    _context.Entry(item).State = EntityState.Modified;
                }

            return true;
        }

        private IIncludableQueryable<Course, Subject> GetBaseQuery()
        {
            var response = _context.Courses.Include(t => t.CurrentConfiguration)
                       .ThenInclude(f => f.EnrollDocuments)
                       .Include(q => q.CurrentConfiguration)
                       .ThenInclude(s => s.Subjects)
                       .ThenInclude(a => a.Subject)
                       ;

            return response;
        }
    }
}