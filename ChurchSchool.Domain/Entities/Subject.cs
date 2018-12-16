using System.Collections.Generic;

namespace ChurchSchool.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        //public IEnumerable<Course_Subject> Configurations { get; set; }
        //public IEnumerable<ProfessorSubject> RelatedProfessors { get; set; }
        public IEnumerable<SubjectClass> RelatedClasses { get; set; }
    }
}