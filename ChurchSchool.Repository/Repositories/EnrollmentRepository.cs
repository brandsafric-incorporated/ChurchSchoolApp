using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Repository.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private RepositoryContext _repositoryContext;

        public EnrollmentRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<Enrollment> Add(Enrollment model)
        {
            _repositoryContext.Enrollments.Add(model);

            await _repositoryContext.SaveChangesAsync();

            return model;
        }

        public IEnumerable<Enrollment> Filter(Enrollment model)
        {
            return _repositoryContext.Enrollments.Where(x => x == model);
        }

        public IEnumerable<Enrollment> GetAll()
        {
            return _repositoryContext.Enrollments;
        }

        public async Task<bool> Remove(Guid key)
        {

            var itemToRemove = await _repositoryContext.Enrollments.FindAsync(key);

            _repositoryContext.Enrollments.Remove(itemToRemove);

            _repositoryContext.SaveChanges();

            return true;
        }

        public async Task<bool> Update(Enrollment model)
        {

            var itemToUpdate = await _repositoryContext.Enrollments.FindAsync(model.Id);

            itemToUpdate = model;

            _repositoryContext.SaveChanges();

            return true;

        }


    }
}
