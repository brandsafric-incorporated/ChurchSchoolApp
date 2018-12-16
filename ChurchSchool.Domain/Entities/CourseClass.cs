using ChurchSchool.Domain.Contracts;
using System;
using System.Linq;

namespace ChurchSchool.Domain.Entities
{
    public class CourseClass : BaseEntity, IValidateObject
    {
        public long CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public Course RelatedCourse { get; set; }

        public bool IsValid()
        {
            if (CourseId < 1)
            {
                AddError("Id de Curso inválido");
            }

            if (StartDate == default(DateTime))
            {
                AddError("Data de Inicio inválida");
            }

            if (FinishDate != default(DateTime) && FinishDate < StartDate)
            {
                AddError("Data de Término não pode ser anterior a data de início");
            }
            
            return !Errors.Any();
        }



        //public Guid? Course_SubjectId { get; set; }
        //public Guid? ProfessorId { get; set; }

        //public string Description { get; set; }
        //public string ClassName { get; set; }

        //public Course_Subject Course_Subject { get; set; }
        //public Professor Professor { get; set; }

        //public bool IsValid()
        //{
        //    if (string.IsNullOrEmpty(ClassName))
        //        AddError("Nome da turma é obrigatório.");

        //    if (ProfessorId == Guid.Empty)
        //        AddError("Informe um professor");

        //    if (Course_SubjectId == Guid.Empty)
        //        AddError("Informe uma disciplina");

        //    return !Errors.Any();
        //}
    }
}