using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchSchool.Repository.Repositories
{
    public class Curriculum_SubjectRepository : ICurriculum_SubjectRepository
    {
        private RepositoryContext _context;

        public Curriculum_SubjectRepository(RepositoryContext context)
        {
            _context = context;
        }

        public Curriculum_Subject Add(Curriculum_Subject model)
        {
            _context.Curriculum_Subject.Add(model);

            return model;
        }

        public IEnumerable<Curriculum_Subject> Filter(Curriculum_Subject model)
        {
            if (model == null)
                return Enumerable.Empty<Curriculum_Subject>();

            return _context.Curriculum_Subject.Where(y => y.Id == model.Id)
                                              .Include(y => y.Curriculum)
                                              .ThenInclude(w => w.ConfigCurriculumns)
                                              .ThenInclude(r => r.Configuration)
                                              .Include(y => y.Curriculum)
                                              .ThenInclude(w => w.ConfigCurriculumns)
                                              .ThenInclude(r => r.Curriculum)
                                              .Include(g => g.Subject);
        }

        public IEnumerable<Curriculum_Subject> GetAll()
        {
            return _context.Curriculum_Subject.Include(y => y.Curriculum)
                                              .Include(g => g.Subject);
        }

        public bool Remove(Guid key)
        {
            var row = Filter(new Curriculum_Subject { Id = key }).FirstOrDefault();

            if (row == null)
            {
                return false;
            }

            row.RemovedDate = DateTime.Now;

            Update(row);

            return true;
        }

        public bool Update(Curriculum_Subject model)
        {
            model.UpdatedDate = DateTime.Now;

            _context.Update(model);

            return true;
        }
    }
}
