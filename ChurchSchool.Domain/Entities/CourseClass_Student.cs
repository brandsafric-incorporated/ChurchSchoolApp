using System;

namespace ChurchSchool.Domain.Entities
{
    public class CourseClass_Student : BaseEntity
    {
        public long CourseClassId { get; set; }
        public long StudentId { get; set; }

        public CourseClass RelatedClass { get; set; }
        public Student Student { get; set; }
    }
}