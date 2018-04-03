using System;

namespace ChurchSchool.Domain.Entities
{
    public class CourseClass_Student : BaseEntity
    {
        public Guid CourseClassId { get; set; }
        public Guid EnrolledStudentId { get; set; }

        public CourseClass RelatedClass { get; set; }
        public Enrollment Enrollment { get; set; }
    }
}