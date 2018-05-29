using ChurchSchool.Domain.Enum;
using System;

namespace ChurchSchool.Domain.Entities
{
    public class CourseDocuments : BaseEntity
    {
        public Guid CourseConfigurationId { get; set; }
        public EDocumentType Type { get; set; }
        public bool IsRequired { get; set; }        
    }
}
