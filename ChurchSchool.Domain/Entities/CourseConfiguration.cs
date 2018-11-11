using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ChurchSchool.Domain.Entities
{
    public class CourseConfiguration : BaseEntity, IValidateObject
    {
        public Guid? CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Description { get; set; }

        public Course RelatedCourse { get; set; }
        public IEnumerable<Course_Subject> Subjects { get; set; }
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
            if (CourseId == Guid.Empty)
            {
                AddError(new Shared.Validations.Error { Message = "Id do curso não fornecido." });
            }

            return !Errors.Any();
        }
    }
}
