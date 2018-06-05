using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Domain.Contracts
{
    public interface ICourseClassRepository
    {
        IEnumerable<Domain.Entities.StudentSubject> GetRelatedSubjects(Guid personId);
    }
}
