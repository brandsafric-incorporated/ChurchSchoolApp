using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.Contracts
{
    public interface ICourseDocumentRepository : IRepository<CourseDocuments>
    {
        bool RemoveByCourseConfiguration(long courseConfigurationId);
        bool AddCourseDocumentRange(IEnumerable<CourseDocuments> documents);
    }
}
