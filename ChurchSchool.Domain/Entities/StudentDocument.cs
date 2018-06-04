using System;

namespace ChurchSchool.Domain.Entities
{
    public class StudentDocument : Document
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
