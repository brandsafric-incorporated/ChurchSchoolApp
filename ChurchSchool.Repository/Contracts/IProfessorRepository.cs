using ChurchSchool.Domain.Entities;

namespace ChurchSchool.Repository.Contracts
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        long GetAvaiableTeacherAmount();
    }
}
