using ChurchSchool.Application.Contracts;
using ChurchSchool.Application.Models;
using ChurchSchool.Repository.Contracts;
using System.Linq;

namespace ChurchSchool.Application.App
{
    public class School : ISchool
    {

        private ICourseRepository _courseRepository;
        private IEnrollmentRepository _enrollmentRepository;
        private IStudentRepository _studentRepository;
        private IProfessorRepository _professorRepository;


        public School(ICourseRepository courseRepository,
                      IEnrollmentRepository enrollmentRepository,
                      IProfessorRepository professorRepository,
                      IStudentRepository studentRepository)
        {
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _professorRepository = professorRepository;
        }

        public SchoolInfoConsolidated GetSchoolInfoConsolidated()
        {
            return new SchoolInfoConsolidated
            {
                ActiveCoursesAmount = _courseRepository.Filter(new Domain.Entities.Course { IsActive = true }).Count(),
                ActiveStudentsAmount = _studentRepository.GetTotalActiveStudents(),
                PendingEnrollmentsAmount = _enrollmentRepository.GetTotalPendingEnrollments(),
                AvaiableTeachersAmount = _professorRepository.GetAvaiableTeacherAmount()
            };
        }
    }
}
