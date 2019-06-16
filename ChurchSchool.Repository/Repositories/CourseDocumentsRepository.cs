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

        public CourseDocument Add(CourseDocument model)
        {
            throw new NotImplementedException();
        }

        public bool AddCourseDocumentRage(IEnumerable<CourseDocument> documents)
        {
            _context.AddRange(documents);
            return true;
        }

        public IEnumerable<CourseDocument> Filter(CourseDocument model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDocument> GetAll()
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

        public bool Update(CourseDocument model)
        {
            throw new NotImplementedException();
        }
    }
}
