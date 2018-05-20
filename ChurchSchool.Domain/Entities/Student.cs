
using ChurchSchool.Domain.Enum;
using ChurchSchool.Shared;
using System;
using System.Collections.Generic;

namespace ChurchSchool.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string EnrollmentID { get; set; }
        public Course Course { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public EEnrollmentStatus Status { get; set; }
        public Person Person { get; set; }
    }
}
