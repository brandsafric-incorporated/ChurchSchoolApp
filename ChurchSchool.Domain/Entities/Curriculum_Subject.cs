﻿using System;

namespace ChurchSchool.Domain.Entities
{
    public class Curriculum_Subject : BaseEntity
    {
        public Guid CurriculumId { get; set; }
        public Guid SubjectId { get; set; }

        public Curriculum Curriculum { get; set; }
        public Subject Subject { get; set; }
    }
}