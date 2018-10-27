using System;
using System.Collections.Generic;

namespace ChurchSchool.Application.Models
{
    /// <summary>
    /// Model which represents the most important information about the course
    /// </summary>
    public class CourseConsolidatedModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Domain.Entities.Subject> Subjects { get; set; }
        public IEnumerable<Domain.Enum.EDocumentType> Documents { get; set; }
    }
}
