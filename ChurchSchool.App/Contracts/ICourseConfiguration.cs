using ChurchSchool.Application;
using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Application.Contracts
{
    public interface ICourseConfiguration : IBasicOperations<Domain.Entities.CourseConfiguration>
    {
        IEnumerable<Domain.Entities.CourseConfiguration> GetByCourse(Guid courseId);
        ValidationResult VinculateSubject(Domain.Entities.Course_Subject model);
    }
}
