using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Domain.Entities
{
    public class CourseConfiguration : BaseEntity, IValidateObject
    {
        public Guid? CourseId { get; set; }        
        public bool IsCurrentConfiguration { get; set; }
        
        public IEnumerable<ConfigurationCurriculum> ConfigCurriculumns { get; set; }
        public IEnumerable<CourseDocuments> EnrollDocuments { get; set; }

        public Course RelatedCourse { get; set; }

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
