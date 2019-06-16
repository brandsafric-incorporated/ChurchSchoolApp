using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ChurchSchool.Domain.Entities
{
    public class Student : BaseEntity, IValidateObject
    {
        public long PersonId { get; set; }
        public long CourseId { get; set; }
        public string EnrollmentID { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        public EEnrollmentStatus Status { get; set; }
        public Course Course { get; set; }
        public Person Person { get; set; }
        public IList<StudentDocument> Documents { get; set; }

        public bool IsValid()
        {
            return !Errors.Any();
        }
    }
}
