using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Domain.Contracts
{
    public interface IProfessorSubjectRepository
    {
        IEnumerable<Domain.Entities.ProfessorSubject> GetRelatedSubjects(Guid professorId);
    }
}
