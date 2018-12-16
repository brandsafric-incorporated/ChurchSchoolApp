using AutoMapper;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Application.Models;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Application
{
    public class Curriculum : ICurriculum
    {

        private readonly ICurriculumRepository _curriculumRepository;
        private readonly ICurriculum_SubjectRepository _curriculumSubjectRepository;
        private readonly IMapper _mapper;

        public Curriculum(
            ICurriculumRepository curriculumRepository,
            ICurriculum_SubjectRepository curriculumSubjectRepository,
            IMapper mapper
        )
        {
            _mapper = mapper;
            _curriculumRepository = curriculumRepository;
            _curriculumSubjectRepository = curriculumSubjectRepository;
        }

        public Domain.Entities.Curriculum Add(Domain.Entities.Curriculum entity)
        {
            var result = _curriculumRepository.Add(entity);

            return result;
        }

        public IEnumerable<CurriculumModel> GetAll()
        {
            var result = _curriculumRepository.GetAll().Select(x =>
            {
                return new CurriculumModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    Subjects = x.Curriculum_Subjects.Select(w => w.Subject)
                };
            });

            return result;
        }

        public Domain.Entities.Curriculum GetById(long id)
        {
            return _curriculumRepository.Filter(new Domain.Entities.Curriculum { Id = id }).FirstOrDefault();
        }

        public ValidationResult Remove(long id)
        {
            _curriculumRepository.Remove(id);
            return new ValidationResult();
        }

        public ValidationResult Update(Domain.Entities.Curriculum entity)
        {
            _curriculumRepository.Update(entity);
            return new ValidationResult();
        }



        IEnumerable<Domain.Entities.Curriculum> IBasicOperations<Domain.Entities.Curriculum>.GetAll()
        {
            return _curriculumRepository.GetAll();
        }

        #region Curriculum Subject

        public Curriculum_Subject VinculateSubject(Curriculum_Subject curriculum_Subject)
        {
            return _curriculumSubjectRepository.Add(curriculum_Subject);
        }

        #endregion
    }
}
