using System;

namespace ChurchSchool.Domain.Entities
{
    public class Frequency : BaseEntity
    {
        public Guid SubjectId { get; set; }
        public Guid StudentId { get; set; }
        public Guid ProfessorId { get; set; }


        public Subject Subject { get; set; }
        public Student Student { get; set; }
        public Professor Professor { get; set; }
        public DateTime Date { get; set; }
    }
}
