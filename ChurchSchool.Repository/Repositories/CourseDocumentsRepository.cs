using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ChurchSchool.Repository.Contracts;

namespace ChurchSchool.Repository.Repositories
{
    public class CourseDocumentRepository : ICourseDocumentRepository
    {
        private readonly RepositoryContext _context;

        public CourseDocumentRepository(RepositoryContext context)
        {
            _context = context;
        }

        public CourseDocuments Add(CourseDocuments model)
        {
            throw new NotImplementedException();
        }

        public bool AddCourseDocumentRange(IEnumerable<CourseDocuments> documents)
        {
            _context.AddRange(documents);
            return true;
        }

        public IEnumerable<CourseDocuments> Filter(CourseDocuments model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDocuments> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(long key)
        {
            throw new NotImplementedException();
        }

        public bool RemoveByCourseConfiguration(long courseConfigurationId)
        {
            var documents = _context.CourseDocuments.Where(t => t.CourseConfigurationId == courseConfigurationId);
            _context.RemoveRange(documents.ToArray());
            return true;
        }

        public bool Update(CourseDocuments model)
        {
            throw new NotImplementedException();
        }
    }
}
