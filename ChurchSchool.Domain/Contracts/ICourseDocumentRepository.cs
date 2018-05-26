﻿using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Domain.Contracts
{
    public interface ICourseDocumentRepository : IRepository<CourseDocuments>
    {
        bool RemoveByCourseConfiguration(Guid courseConfigurationId);
        bool AddCourseDocumentRage(IEnumerable<CourseDocuments> documents);
    }
}
