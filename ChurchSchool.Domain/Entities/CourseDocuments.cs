using ChurchSchool.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Domain.Entities
{
    public class CourseDocuments : BaseEntity
    {
        public EDocumentType Type { get; set; }
        public bool IsRequired { get; set; }
        public Guid CourseConfigurationId { get; set; }
    }
}
