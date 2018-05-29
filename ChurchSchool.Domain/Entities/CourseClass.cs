using System;
using System.Collections.Generic;

namespace ChurchSchool.Domain.Entities
{
    public class CourseClass : BaseEntity
    {
        public Guid Curriculum_SubjectId { get; set; }
        public Guid ProfessorId { get; set; }

        public string Description { get; set; }
        public string ClassName { get; set; }

        public Curriculum_Subject Curriculum_Subject { get; set; }
        public Professor Professor { get; set; }
    }
}