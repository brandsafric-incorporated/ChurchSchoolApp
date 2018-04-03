using System;

namespace ChurchSchool.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}