using System;

namespace ChurchSchool.Domain.Entities
{
    public class CourseClass : BaseEntity
    {
        public Guid ScholarTermId { get; set; }
        public Guid CurriculumId { get; set; }
        public string Description { get; set; }
        

        public ScholarTerm ScholarTerm { get; set; }
        public Curriculum Curriculum { get; set; }        
    }
}