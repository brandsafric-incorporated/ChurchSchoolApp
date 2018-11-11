using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Repository.Repositories
{
    public class CourseClassRepository : ICourseClassRepository
    {
        private readonly RepositoryContext _context;

        private readonly Func<CourseClass, CourseClass, bool> FilterBaseFunc = (a, b) =>
        {
            return a.Description == b.Description || a.Id == b.Id;
        };

        public CourseClassRepository(RepositoryContext context)
        {
            _context = context;
        }

        public CourseClass Add(CourseClass model)
        {
            _context.Classes.Add(model);
            return model;
        }

        public IEnumerable<CourseClass> Filter(CourseClass model)
        {
            if (model == null)
                return Enumerable.Empty<CourseClass>();

            return GetSqlBaseQuery().Where(j => FilterBaseFunc(j, model));

        }

        private IEnumerable<CourseClass> GetSqlBaseQuery()
        {
            return _context.Classes.Include(a => a.Course_Subject)
                                   .ThenInclude(b => b.CourseConfiguration)
                                   .ThenInclude(c => c.RelatedCourse)
                                   .Include(d => d.Course_Subject)
                                   .ThenInclude(e => e.Subject)
                                   .Include(f => f.Professor)
                                   ;
        }

        public IEnumerable<CourseClass> GetAll()
        {
            return GetSqlBaseQuery();
        }

        public IEnumerable<StudentSubject> GetRelatedSubjects(Guid personId)
        {
            var result = (from student in _context.Students
                          join courseClass in _context.CourseClass_Student on student.Id equals courseClass.StudentId
                          join classes in _context.Classes on courseClass.CourseClassId equals classes.Id
                          join courseSubject in _context.Course_Subject on classes.Course_SubjectId equals courseSubject.Id
                          where student.PersonId == personId
                          select new StudentSubject
                          {
                              Student = student,
                              Subject = courseSubject.Subject
                          });

            return result;
        }

        public bool Remove(Guid key)
        {
            var row = _context.Classes.FirstOrDefault(q => q.Id == key);

            if (row == null)
                return false;

            row.RemovedDate = DateTime.Now;

            return Update(row);
        }

        public bool Update(CourseClass model)
        {
            model.UpdatedDate = DateTime.Now;
            _context.Update(model);
            return true;
        }
    }
}
