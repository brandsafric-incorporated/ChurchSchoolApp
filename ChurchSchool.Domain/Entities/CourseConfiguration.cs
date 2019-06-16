using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Domain.Entities
{
    public class CourseConfiguration : BaseEntity, IValidateObject
    {
        public long CourseId { get; set; }        
        public bool IsCurrentConfiguration { get; set; }
        public Course RelatedCourse { get; set; }
        public IEnumerable<ConfigurationCurriculum> ConfigCurriculumns { get; set; }
        public IEnumerable<CourseDocument> EnrollDocuments { get; set; }

        public bool IsValid()
        {
            if (CourseId == default(long))
            {
                AddError(new Shared.Validations.Error { Message = "Id do curso não fornecido." });
            }            

            return !Errors.Any();
        }
    }
}
