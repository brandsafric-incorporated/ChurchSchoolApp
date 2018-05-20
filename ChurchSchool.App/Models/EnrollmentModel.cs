using Entities = ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Application.Models
{
    public class EnrollmentModel
    {
        public Entities.Course RelatedCourse { get; set; }
        //public IEnumerable<CourseClass> RelatedClasses { get; set; }
        public Entities.Student Student { get; set; }
    }
}
