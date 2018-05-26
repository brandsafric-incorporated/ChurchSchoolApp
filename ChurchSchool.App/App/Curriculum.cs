using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchSchool.Application.App
{
    public class Curriculum : ICurriculum
    {
        private readonly ICurriculumRepository _curriculumRepository;

        public Curriculum(ICurriculumRepository curriculumRepository)
        {
            _curriculumRepository = curriculumRepository;
        }

        public Domain.Entities.Curriculum Add(Domain.Entities.Curriculum entity)
        {
            var result = _curriculumRepository.Add(entity);

            return result;
        }

        public IEnumerable<Domain.Entities.Curriculum> GetAll()
        {
            return _curriculumRepository.GetAll();
        }

        public Domain.Entities.Curriculum GetById(Guid id)
        {
            return _curriculumRepository.Filter(new Domain.Entities.Curriculum { Id = id }).FirstOrDefault();
        }

        public ValidationResult Remove(Guid id)
        {
            _curriculumRepository.Remove(id);
            return new ValidationResult();
        }

        public ValidationResult Update(Domain.Entities.Curriculum entity)
        {
            _curriculumRepository.Update(entity);
            return new ValidationResult();
        }
    }
}
