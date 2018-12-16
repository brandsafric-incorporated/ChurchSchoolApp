using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Domain.Entities
{
    public class Student : BaseEntity, IValidateObject
    {
        public long PersonId { get; set; }
        public long CourseClassId { get; set; }
        public string EnrollmentID { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        public EEnrollmentStatus Status { get; set; }

        #region Navigation Properties

        public CourseClass Course { get; set; }

        public Person Person { get; set; }

        public IList<StudentDocument> Documents { get; set; }

        #endregion

        public bool IsValid()
        {
            if (PersonId < 1)
                AddError("Id de Pessoa Inválido");

            if (CourseClassId < 1)
                AddError("Id de Turma Inválido");

            return !Errors.Any();
        }
    }
}
