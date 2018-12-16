using System;

namespace ChurchSchool.Domain.Entities
{
    public class Frequency : BaseEntity
    {
        public long SubjectId { get; set; }
        public long StudentId { get; set; }
        public long ProfessorId { get; set; }


        public Subject Subject { get; set; }
        public Student Student { get; set; }
        public Professor Professor { get; set; }
        public DateTime Date { get; set; }
    }
}
