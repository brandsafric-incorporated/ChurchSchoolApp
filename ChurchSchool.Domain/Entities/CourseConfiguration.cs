using System;
using System.Collections.Generic;

namespace ChurchSchool.Domain.Entities
{
    public class CourseConfiguration : BaseEntity
    {
        public Guid CourseId { get; set; }
        //public Guid CurriculumId { get; set; }
        public bool IsCurrentConfiguration { get; set; }


        public IEnumerable<Course> RelatedCourses { get; set; }
        //public Curriculum RelatedCurriculum { get; set; }
    }
}
