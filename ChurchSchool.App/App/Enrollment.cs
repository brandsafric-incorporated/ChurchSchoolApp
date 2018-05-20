using ChurchSchool.Application.Contracts;
using ChurchSchool.Application.Models;
using ChurchSchool.Domain.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChurchSchool.Application
{
    public class Enrollment : IEnrollment
    {
        public Task<Models.EnrollmentModel> Enroll(Models.EnrollmentModel enrollmentData)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Models.EnrollmentModel> Filter(Models.EnrollmentModel filterParameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
