using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace ChurchSchool.Domain.Entities
{
    public class CourseConfiguration : BaseEntity, IValidateObject
    {
        public long? CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Description { get; set; }
        public int PercentageOfAbsenseByClass { get; set; }
        public int LowestGradetoBeApproved { get; set; }
        
        public Course RelatedCourse { get; set; }
        
        public IEnumerable<CourseDocuments> EnrollDocuments { get; set; }

        [NotMapped]
        public bool IsCurrent
        {
            get
            {
                return this.FinishDate == null;
            }
        }

        public bool IsValid()
        {
            if (CourseId < 1)
            {
                AddError(new Shared.Validations.Error { Message = "Id do curso não fornecido." });
            }

            return !Errors.Any();
        }
    }
}
