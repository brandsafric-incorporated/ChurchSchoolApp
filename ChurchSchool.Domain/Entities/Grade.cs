using ChurchSchool.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Domain.Entities
{
    public class Grade : BaseEntity
    {
        public Subject Subject { get; set; }
        public Enrollment Enrollment { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public ScholarTerm ScholarTerm { get; set; }
        public IEnumerable<GradeHistory> History { get; set; }
    }
}