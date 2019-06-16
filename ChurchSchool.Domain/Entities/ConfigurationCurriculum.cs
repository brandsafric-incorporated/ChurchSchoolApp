using ChurchSchool.Domain.Contracts;
using System;
using System.Linq;

namespace ChurchSchool.Domain.Entities
{
    public class ConfigurationCurriculum : BaseEntity, IValidateObject
    {
        public long  ConfigurationId { get; set; }
        public long  CurriculumId { get; set; }
        public bool IsCurrentConfiguration { get; set; }
        public bool IsActive { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public Curriculum Curriculum { get; set; }
        public CourseConfiguration Configuration { get; set; }
        
        public bool IsValid()
        {
            if (ConfigurationId == default(long))
            {
                AddError("Configuração Inválida ou vazia");
            }

            if (CurriculumId == default(long))
            {
                AddError("Curriculo Inválido ou não fornecido");
            }

            if (StartDate == default(DateTime))
            {
                AddError("Data de Início inválida");
            }

            if (FinishDate != null)
            {
                if (FinishDate < StartDate)
                    AddError("A Data de Início deve ser anterior a data de término.");

                if (FinishDate <= DateTime.Now)
                    AddError($"A data de término deve valer pelo menos um dia além da data cadastrada {DateTime.Now: dd/MM/yyyy}");
            }

            return !Errors.Any();
        }
    }
}
