using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ChurchSchool.Repository.Repositories
{
    public class CurriculumRepository : ICurriculumRepository
    {
        private readonly RepositoryContext _repository;

        public CurriculumRepository(RepositoryContext repository)
        {
            _repository = repository;
        }

        public Curriculum Add(Curriculum model)
        {
            _repository.Curriculums.Add(model);

            _repository.SaveChanges();

            return model;
        }

        public IEnumerable<Curriculum> Filter(Curriculum model)
        {
            return _repository.Curriculums.AsNoTracking().Where(y => y == model);
        }

        public IEnumerable<Curriculum> GetAll()
        {
            return _repository.Curriculums.AsNoTracking();
        }

        public bool Remove(Guid key)
        {
            var itemToRemove = _repository.Curriculums.FirstOrDefault(y => y.Id == key);

            itemToRemove.RemovedDate = DateTime.Now;

            _repository.SaveChanges();

            return true;
        }

        public bool Update(Curriculum model)
        {
            model.UpdatedDate = DateTime.Now;
            _repository.Curriculums.Update(model);
            _repository.SaveChanges();

            return true;
        }
    }
}
