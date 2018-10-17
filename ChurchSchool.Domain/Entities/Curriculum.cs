using ChurchSchool.Domain.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Domain.Entities
{
    public class Curriculum : BaseEntity, IValidateObject
    {
        public string Description { get; set; }

        public IEnumerable<ConfigurationCurriculum> ConfigCurriculumns { get; set; }
        public IEnumerable<Curriculum_Subject> Curriculum_Subjects { get; set; }
        
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Description))
            {
                AddError("Preencha uma informação para a descrição do curriculo escolar.");
            }

            return !Errors.Any();
        }
    }
}