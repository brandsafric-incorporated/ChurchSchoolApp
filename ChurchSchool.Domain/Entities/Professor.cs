using System;
using System.Collections.Generic;

namespace ChurchSchool.Domain.Entities
{
    public class Professor : BaseEntity
    {
        public string EnrollmentID { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public IEnumerable<ProfessorSubject> RelatedSubjects { get; set; }

        public Professor()
        {
            RelatedSubjects = new List<ProfessorSubject>();
        }
    }
}
