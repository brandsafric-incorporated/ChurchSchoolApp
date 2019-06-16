using System;

namespace ChurchSchool.Domain.Entities
{
    public class Curriculum_Subject : BaseEntity
    {
        public long CurriculumId { get; set; }
        public long SubjectId { get; set; }

        public Curriculum Curriculum { get; set; }
        public Subject Subject { get; set; }
    }
}