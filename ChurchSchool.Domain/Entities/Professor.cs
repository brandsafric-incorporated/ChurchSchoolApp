using System;
using System.Collections.Generic;

namespace ChurchSchool.Domain.Entities
{
    public class Professor : BaseEntity
    {
        public string EnrollmentID { get; set; }
        public long PersonId { get; set; }
        public Person Person { get; set; }        
        public IEnumerable<SubjectClass> RelatedSubjects { get; set; }

        public Professor()
        {
            RelatedSubjects = new List<SubjectClass>();
        }
    }
}
