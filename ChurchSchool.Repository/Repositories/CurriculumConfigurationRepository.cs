using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Repository.Repositories
{

    public class CurriculumConfigurationRepository : ICurriculumConfigurationRepository
    {
        private readonly RepositoryContext _context;

        public CurriculumConfigurationRepository(RepositoryContext context) => _context = context;

        public ConfigurationCurriculum Add(ConfigurationCurriculum model)
        {
            _context.ConfigurationCurriculum.Add(model);
            return model;
        }

        public IEnumerable<ConfigurationCurriculum> Filter(ConfigurationCurriculum model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConfigurationCurriculum> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(long key)
        {
            throw new NotImplementedException();
        }

        public bool Update(ConfigurationCurriculum model)
        {
            throw new NotImplementedException();
        }
    }
}
