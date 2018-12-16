using ChurchSchool.Domain.Contracts;
using System;
using System.Linq;

namespace ChurchSchool.Domain.Entities
{
    public class SubjectClass : BaseEntity, IValidateObject
    {
        public long ProfessorId { get; set; }
        public long SubjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }


        #region Navigation Properties

        public Professor Professor { get; set; }
        public Subject Subject { get; set; }

        #endregion

        public bool IsValid()
        {
            if (ProfessorId < 1)
                AddError("Id de professor inválido");

            if (SubjectId < 1)
                AddError("Id de matéria inválido");

            if (StartDate == default(DateTime))
                AddError("Data de início inválida.");

            if (FinishDate != null && FinishDate < StartDate)
                AddError("Data de término de ser posterior a data de início.");

            return !Errors.Any();
        }
    }
}
