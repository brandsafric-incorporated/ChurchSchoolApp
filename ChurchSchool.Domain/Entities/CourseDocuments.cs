using ChurchSchool.Domain.Enum;
using System;

namespace ChurchSchool.Domain.Entities
{
    public class CourseDocument : BaseEntity
    {
        public long CourseConfigurationId { get; set; }
        public EDocumentType Type { get; set; }
        public bool IsRequired { get; set; }        
    }
}
