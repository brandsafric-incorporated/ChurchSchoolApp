using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Domain.Contracts
{
    public interface ICourseConfigurationRepository : IRepository<CourseConfiguration>
    {
        IEnumerable<CourseConfiguration> GetByCourse(Guid courseId);
    }
}
