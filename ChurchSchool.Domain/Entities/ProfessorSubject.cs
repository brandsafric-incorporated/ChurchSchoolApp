using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Domain.Entities
{
    public class ProfessorSubject : BaseEntity
    {
        public long ProfessorId { get; set; }
        public long SubjectId { get; set; }

        public Professor Professor { get; set; }
        public Subject Subject { get; set; }
    }
}
