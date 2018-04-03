using System;

namespace ChurchSchool.Domain.Entities
{
    public class Frequency : BaseEntity
    {
        public ScholarTerm ScholarTerm { get; set; }
        public Subject Subject { get; set; }
        public Enrollment Enrollment { get; set; }
        public DateTime Date { get; set; }
    }
}