using System.Threading.Tasks;

namespace ChurchSchool.Domain.Contracts
{
    public interface IEnrollmentRepository
    {
        Task<EnrollmentModel> Enroll(EnrollmentModel enrollmentData);
    }
}
