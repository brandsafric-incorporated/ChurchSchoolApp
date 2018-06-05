using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
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
    }
}
