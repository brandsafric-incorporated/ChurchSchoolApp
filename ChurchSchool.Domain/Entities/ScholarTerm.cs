using System;

namespace ChurchSchool.Domain.Entities
{
    public class ScholarTerm : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Description { get; set; }
    }
}