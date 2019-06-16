using ChurchSchool.Domain.Contracts;
using System.Linq;

namespace ChurchSchool.Domain.Entities
{
    public class Course : BaseEntity, IValidateObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseConfiguration CurrentConfiguration { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                AddError("Nome é obrigatório");
            }

            if (this.CurrentConfiguration == null)
            {
                AddError("Configuração é obrigatório");
            }

            return !Errors.Any();
        }
    }
}