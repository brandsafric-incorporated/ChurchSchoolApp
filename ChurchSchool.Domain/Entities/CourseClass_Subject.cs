using System;

namespace ChurchSchool.Domain.Entities
{
    public class CourseClass_Subject : BaseEntity
    {
        public Guid CourseClassId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid ProfessorId { get; set; }

        public CourseClass RelatedClass { get; set; }
        public Professor Professor { get; set; }
        public Subject Subject { get; set; }
    }
}