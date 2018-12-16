using System;

namespace ChurchSchool.Domain.Entities
{
    public class CourseClass_Subject : BaseEntity
    {
        public long CourseClassId { get; set; }
        public long SubjectId { get; set; }
        
        public CourseClass RelatedClass { get; set; }        
        public Subject Subject { get; set; }
        
        //public Guid ProfessorId { get; set; }
        //public Professor Professor { get; set; }
    }
}