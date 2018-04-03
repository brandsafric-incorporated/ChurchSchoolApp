using System.Collections.Generic;

namespace ChurchSchool.Domain.Entities
{
    public class CourseClass : BaseEntity
    {
        public string Description { get; set; }
        public ScholarTerm ScholarTerm { get; set; }
        public Curriculum Curriculum { get; set; }        
    }
}