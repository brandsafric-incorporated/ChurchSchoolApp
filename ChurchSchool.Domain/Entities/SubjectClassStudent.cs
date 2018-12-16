using ChurchSchool.Domain.Contracts;
using System;
using System.Linq;

namespace ChurchSchool.Domain.Entities
{
    public class SubjectClassStudent : BaseEntity, IValidateObject
    {
        public long StudentId { get; set; }
        public long SubjectClassId { get; set; }

        #region Navigation Properties

        public Student Student { get; set; }
        public SubjectClass SubjectClass { get; set; }

        #endregion

        public bool IsValid()
        {
            if (StudentId < 1)
                AddError("Id de Estudante Inválido");

            if (SubjectClassId < 1)
                AddError("Id de classe inválido");

            return !Errors.Any();
        }
    }
}
