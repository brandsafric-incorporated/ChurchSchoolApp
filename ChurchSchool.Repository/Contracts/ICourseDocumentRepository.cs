using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.Contracts
{
    public interface ICourseDocumentRepository : IRepository<CourseDocument>
    {
        bool RemoveByCourseConfiguration(long courseConfigurationId);
        bool AddCourseDocumentRage(IEnumerable<CourseDocument> documents);
    }
}
