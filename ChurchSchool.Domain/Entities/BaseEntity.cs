using ChurchSchool.Shared.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchSchool.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid? Id { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? RemovedDate { get; set; }

        [NotMapped]
        public IEnumerable<Error> Errors { get; set; }

        public BaseEntity()
        {
            this.Errors = new List<Error>();
        }
    }
}