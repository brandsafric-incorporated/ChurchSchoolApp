using System;

namespace ChurchSchool.Domain.Entities
{
    public class StudentDocument : Document
    {
        public long StudentId { get; set; }
        public Student Student { get; set; }
    }
}
