using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchSchool.Repository.Repositories
{
    public class ProfessorSubjectRepository : IProfessorSubjectRepository
    {
        private RepositoryContext _context;

        public ProfessorSubjectRepository(RepositoryContext context)
        {
            _context = context;
        }

        public IEnumerable<ProfessorSubject> GetRelatedSubjects(long professorId)
        {
            //return _context.ProfessorSubject.Where(x => x.ProfessorId == professorId);
            return null;
        }
    }
}
