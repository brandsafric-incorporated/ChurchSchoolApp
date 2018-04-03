
using ChurchSchool.Domain.Enum;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Domain.Entities
{
    public class Enrollment : BaseEntity
    {
        public Course Course { get; set; }
        public Student Student { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public EnrollmentStatus Status { get; set; }
    }
}
