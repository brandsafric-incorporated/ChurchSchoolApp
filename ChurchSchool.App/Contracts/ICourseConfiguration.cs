using ChurchSchool.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Application.Contracts
{
    public interface ICourseConfiguration : IBasicOperations<Domain.Entities.CourseConfiguration>
    {
        IEnumerable<Domain.Entities.CourseConfiguration> GetByCourse(long courseId);
    }
}
