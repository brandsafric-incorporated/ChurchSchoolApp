using ChurchSchool.Domain.Contracts;
using System.Threading.Tasks;

namespace ChurchSchool.Repository.Contracts
{
    public interface IEnrollmentRepository
    {
        Task<EnrollmentModel> Enroll(EnrollmentModel enrollmentData);
        long GetTotalPendingEnrollments();
    }
}
