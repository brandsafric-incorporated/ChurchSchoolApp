using System;
using System.Collections.Generic;

namespace ChurchSchool.Domain.Entities
{
    public class CourseClass : BaseEntity
    {   
        public Guid CurriculumId { get; set; }
        public string Description { get; set; }       
        
        public Curriculum Curriculum { get; set; }        
    }
}