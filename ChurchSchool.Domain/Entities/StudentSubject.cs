using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Domain.Entities
{
    public class StudentSubject
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
