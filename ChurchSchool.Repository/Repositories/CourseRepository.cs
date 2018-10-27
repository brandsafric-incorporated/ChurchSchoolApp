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
            return this.GetConsolidatedCourseData().Where(x => CourseFilter(x, model));
        }

        public IEnumerable<Course> GetActiveCourses()
        {
            return _context.Courses.Where(c => c.isActive);
        }

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

        public IEnumerable<Course> GetConsolidatedData()
        {
            return GetConsolidatedCourseData();
        }

        private IIncludableQueryable<Course, Subject> GetConsolidatedCourseData()
        {
            var response = _context.Courses.Include(t => t.CurrentConfiguration)
                       .ThenInclude(f => f.EnrollDocuments)
                       .Include(q => q.CurrentConfiguration)
                       .ThenInclude(s => s.ConfigCurriculumns)
                       .ThenInclude(a => a.Curriculum)
                       .ThenInclude(w => w.Curriculum_Subjects)
                       .ThenInclude(v => v.Subject)
                       ;

            foreach (var obj in response.Where(obj =>
                                            obj.CurrentConfiguration != null &&
                                            obj.CurrentConfiguration.ConfigCurriculumns != null &&
                                            obj.CurrentConfiguration.ConfigCurriculumns.Count() > 1)
                                            )
            {
                obj.CurrentConfiguration.ConfigCurriculumns = obj.CurrentConfiguration.ConfigCurriculumns.Where(x => x.IsActive);
            }

            return response;
        }
    }
}