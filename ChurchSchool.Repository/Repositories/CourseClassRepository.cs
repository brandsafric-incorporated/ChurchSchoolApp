using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchSchool.Repository.Repositories
{
    public class CourseClassRepository : ICourseClassRepository
    {
        private readonly RepositoryContext _context;

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

            return _context.Classes.Where(q => q.Id == model.Id)
                                   .Include(a => a.Curriculum_Subject)
                                   .ThenInclude(c => c.Curriculum)
                                   .Include(a => a.Curriculum_Subject)
                                   .ThenInclude(c => c.Subject)
                                   .Include(b => b.Professor);
        }

        public IEnumerable<CourseClass> GetAll()
        {
            return _context.Classes.Include(a => a.Curriculum_Subject)
                                   .ThenInclude(c => c.Curriculum)
                                   .Include(a => a.Curriculum_Subject)
                                   .ThenInclude(c => c.Subject)
                                   .Include(b => b.Professor);
        }

        public IEnumerable<StudentSubject> GetRelatedSubjects(Guid personId)
        {
            var result = (from student in _context.Students
                          join courseClass in _context.CourseClass_Student on student.Id equals courseClass.StudentId
                          join classes in _context.Classes on courseClass.CourseClassId equals classes.Id
                          join curriculumSubject in _context.Curriculum_Subject on classes.Curriculum_SubjectId equals curriculumSubject.Id
                          where student.PersonId == personId
                          select new StudentSubject
                          {
                              Student = student,
                              Subject = curriculumSubject.Subject
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
