using ChurchSchool.Domain.Enum;
using System;

namespace ChurchSchool.Domain.Entities
{
    public class GradeHistory : BaseEntity
    {
        public Grade CurrentGrade { get; set; }
    }
}