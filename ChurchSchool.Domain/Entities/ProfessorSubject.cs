using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Domain.Entities
{
    public class ProfessorSubject : BaseEntity
    {
        public Guid ProfessorId { get; set; }
        public Guid SubjectId { get; set; }

        public Professor Professor { get; set; }
        public Subject Subject { get; set; }
    }
}
