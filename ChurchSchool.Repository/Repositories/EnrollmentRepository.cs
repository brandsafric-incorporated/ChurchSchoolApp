using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChurchSchool.Repository.Contracts;
using ChurchSchool.Domain.Enum;

namespace ChurchSchool.Repository.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly RepositoryContext _context;

        public EnrollmentRepository(RepositoryContext context) => _context = context;


        public Task<EnrollmentModel> Enroll(EnrollmentModel enrollmentData)
        {
            throw new NotImplementedException();
        }

        public long GetTotalPendingEnrollments()
        {
            var result = (from student in _context.Students
                          join course in _context.Courses on student.CourseId equals course.Id
                          where student.Status == EEnrollmentStatus.WAITING_APROVEMENT && course.isActive
                          select student
                          ).LongCount();

            return result;
        }
    }
}
