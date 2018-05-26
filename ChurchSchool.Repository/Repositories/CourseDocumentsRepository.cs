using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.Repositories
{
    public class CourseDocumentRepository : ICourseDocumentRepository
    {
        private RepositoryContext _repositoryContext;

        public CourseDocumentRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public CourseDocuments Add(CourseDocuments model)
        {
            throw new NotImplementedException();
        }

        public bool AddCourseDocumentRage(IEnumerable<CourseDocuments> documents)
        {
            _repositoryContext.AddRange(documents);
            _repositoryContext.SaveChanges();
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

        public bool Remove(Guid key)
        {
            throw new NotImplementedException();
        }

        public bool RemoveByCourseConfiguration(Guid courseConfigurationId)
        {
            var documents = _repositoryContext.CourseDocuments.Where(t => t.CourseConfigurationId == courseConfigurationId);

            _repositoryContext.RemoveRange(documents.ToArray());

            _repositoryContext.SaveChanges();

            return true;
        }

        public bool Update(CourseDocuments model)
        {
            throw new NotImplementedException();
        }
    }
}
