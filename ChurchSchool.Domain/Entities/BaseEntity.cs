using ChurchSchool.Shared.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchSchool.Domain.Entities
{
    public abstract class BaseEntity : ValidationResult
    {
        public long? Id { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? RemovedDate { get; set; }

        public BaseEntity() : base()
        {
        }
    }
}