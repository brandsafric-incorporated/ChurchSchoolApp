using AutoMapper;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Repository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChurchSchool.Application
{
    public class Enrollment : IEnrollment
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public Enrollment(
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IMapper mapper
        )
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public Task<Models.EnrollmentModel> Enroll(Models.EnrollmentModel enrollmentData)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Models.EnrollmentModel> Filter(Models.EnrollmentModel filterParameters)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Models.EnrollmentModel> GetPendingEnrollments()
        {
            var queryResult = _mapper.Map<IEnumerable<Models.EnrollmentModel>>(_studentRepository.GetPendingEnrollments());

            return queryResult;
        }
    }
}
