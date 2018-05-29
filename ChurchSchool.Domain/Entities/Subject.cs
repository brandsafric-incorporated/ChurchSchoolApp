using System.Collections.Generic;

namespace ChurchSchool.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<ProfessorSubject> RelatedProfessors { get; set; }
    }
}