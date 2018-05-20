using System.Collections.Generic;

namespace ChurchSchool.Domain.Entities
{
    public class Professor : BaseEntity
    {
        public string EnrollmentID { get; set; }
        public Person Person { get; set; }
        public IEnumerable<Subject> RelatedSubjects { get; set; }
    }
}
