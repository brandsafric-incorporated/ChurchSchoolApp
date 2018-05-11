using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Repository.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private RepositoryContext _repositoryContext;

        public CourseRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<Course> Add(Course model)
        {
            _repositoryContext.Courses.Add(model);

            await _repositoryContext.SaveChangesAsync();

            return model;
        }

        public IEnumerable<Course> Filter(Course model)
        {
            return _repositoryContext.Courses.Where(x => x == model);
        }

        public IEnumerable<Course> GetAll()
        {
            return _repositoryContext.Courses;
        }

        public async Task<bool> Remove(Guid key)
        {

            var itemToRemove = await _repositoryContext.Students.FindAsync(key);

            _repositoryContext.Students.Remove(itemToRemove);

            _repositoryContext.SaveChanges();

            return true;
        }

        public async Task<bool> Update(Course model)
        {

            var itemToUpdate = await _repositoryContext.Courses.FindAsync(model.Id);

            itemToUpdate = model;

            _repositoryContext.SaveChanges();

            return true;

        }


    }
}
