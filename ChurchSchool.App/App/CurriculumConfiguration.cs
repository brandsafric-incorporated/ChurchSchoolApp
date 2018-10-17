using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Application.App
{
    public class CurriculumConfiguration : ICurriculumConfiguration
    {
        private readonly ICurriculumConfigurationRepository _repository;

        public CurriculumConfiguration(ICurriculumConfigurationRepository repository)
        {
            _repository = repository;
        }

        public Domain.Entities.ConfigurationCurriculum Add(Domain.Entities.ConfigurationCurriculum settings)
        {
            return _repository.Add(settings);            
        }
    }
}
