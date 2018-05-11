using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Repository.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private RepositoryContext _repositoryContext;

        public StudentRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<Student> Add(Student model)
        {
            _repositoryContext.Students.Add(model);

            await _repositoryContext.SaveChangesAsync();

            return model;
        }

        public IEnumerable<Student> Filter(Student model)
        {
            return _repositoryContext.Students.Where(x => x == model);
        }

        public IEnumerable<Student> GetAll()
        {
            return _repositoryContext.Students;
        }

        public async Task<bool> Remove(Guid key)
        {

            var itemToRemove = await _repositoryContext.Students.FindAsync(key);

            _repositoryContext.Students.Remove(itemToRemove);

            _repositoryContext.SaveChanges();

            return true;
        }

        public async Task<bool> Update(Student model)
        {

            var itemToUpdate = await _repositoryContext.Students.FindAsync(model.Id);

            itemToUpdate = model;

            _repositoryContext.SaveChanges();

            return true;

        }


    }
}
