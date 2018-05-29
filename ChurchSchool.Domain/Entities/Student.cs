using ChurchSchool.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchSchool.Domain.Entities
{
    public class Student : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Guid CourseId { get; set; }
        public string EnrollmentID { get; set; }        
        public DateTime? EnrollmentDate { get; set; }        

        public EEnrollmentStatus Status { get; set; }
        public Course Course { get; set; }

        [NotMapped]
        public Person Person { get; set; }
    }
}
