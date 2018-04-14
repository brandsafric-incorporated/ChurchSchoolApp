using System;

namespace ChurchSchool.Domain.Entities
{
    public class Frequency : BaseEntity
    {
        public Guid ScholarTermId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid EnrollmentId { get; set; }

        public ScholarTerm ScholarTerm { get; set; }
        public Subject Subject { get; set; }
        public Enrollment Enrollment { get; set; }
        public DateTime Date { get; set; }
    }
}