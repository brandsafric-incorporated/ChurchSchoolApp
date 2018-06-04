using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ChurchSchool.Repository.Repositories
{
    public class CurriculumRepository : ICurriculumRepository
    {
        private readonly RepositoryContext _context;

        public CurriculumRepository(RepositoryContext context) => _context = context;

        public Curriculum Add(Curriculum model)
        {
            _context.Curriculums.Add(model);
            return model;
        }

        public IEnumerable<Curriculum> Filter(Curriculum model) => _context.Curriculums.Where(y => y == model);
        public IEnumerable<Curriculum> GetAll() => _context.Curriculums;


        public bool Remove(Guid key)
        {
            var itemToRemove = _context.Curriculums.FirstOrDefault(y => y.Id == key);
            itemToRemove.RemovedDate = DateTime.Now;
            return true;
        }

        public bool Update(Curriculum model)
        {
            model.UpdatedDate = DateTime.Now;
            _context.Curriculums.Update(model);
            return true;
        }
    }
}
