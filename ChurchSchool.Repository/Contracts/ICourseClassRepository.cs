using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.Contracts
{
    public interface ICourseClassRepository : IRepository<CourseClass>
    {
        IEnumerable<Domain.Entities.StudentSubject> GetRelatedSubjects(long personId);
    }
}
