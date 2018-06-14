using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Domain.Entities
{
    public class CourseClass : BaseEntity, IValidateObject
    {
        public Guid Curriculum_SubjectId { get; set; }
        public Guid ProfessorId { get; set; }

        public string Description { get; set; }
        public string ClassName { get; set; }

        public Curriculum_Subject Curriculum_Subject { get; set; }
        public Professor Professor { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(ClassName))
                AddError("Nome da turma é obrigatório.");

            if (ProfessorId == Guid.Empty)
                AddError("Informe um professor");

            if (Curriculum_SubjectId == Guid.Empty)
                AddError("Informe uma disciplina");

            return !Errors.Any();
        }
    }
}