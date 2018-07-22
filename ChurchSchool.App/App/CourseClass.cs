using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchSchool.Application
{
    public class CourseClass : ICourseClass
    {
        private ICourseClassRepository _courseClassRepository;
        private IProfessorSubjectRepository _professorSubjectRepository;
        private ICurriculum_SubjectRepository _curriculum_SubjectRepository;

        public CourseClass(ICourseClassRepository courseClassRepository,
                           IProfessorSubjectRepository professorSubjectRepository,
                           ICurriculum_SubjectRepository curriculum_SubjectRepository
                           )
        {
            _courseClassRepository = courseClassRepository;
            _curriculum_SubjectRepository = curriculum_SubjectRepository;
            _professorSubjectRepository = professorSubjectRepository;
        }

        public Domain.Entities.CourseClass Add(Domain.Entities.CourseClass entity)
        {
            if (!entity.IsValid())
            {
                return entity;
            }

            var subjectId = _curriculum_SubjectRepository.GetAll().FirstOrDefault(w => w.Id == entity.Curriculum_SubjectId)?.SubjectId;

            if (!subjectId.HasValue || !CheckIfSubjectIsEnabled(entity.Curriculum_SubjectId))
            {
                entity.AddError("Disciplina não disponível");
            }

            if (!CheckIfProfessorIsAuthorized(entity.ProfessorId, subjectId.Value))
            {
                entity.AddError($"Professor não habilitado para esta disciplina.");
            }

            _courseClassRepository.Add(entity);

            return entity;
        }

        private bool CheckIfProfessorIsAuthorized(Guid professorId, Guid subjectId)
        {
            return _professorSubjectRepository.GetRelatedSubjects(professorId)
                                              .Any(x => x.SubjectId == subjectId);
        }

        private bool CheckIfSubjectIsEnabled(Guid curriculum_SubjectId)
        {
            var isSubjectEnabled = _curriculum_SubjectRepository.Filter(new Curriculum_Subject { Id = curriculum_SubjectId })
                                                 .Any(y =>
                                                 {
                                                     return y.Curriculum.ConfigCurriculumns.Any(q => q.IsCurrentConfiguration && q.IsActive);
                                                 });
            return isSubjectEnabled;
        }

        public IEnumerable<Domain.Entities.CourseClass> GetAll()
        {
            return _courseClassRepository.GetAll();
        }

        public Domain.Entities.CourseClass GetById(Guid id)
        {
            return _courseClassRepository.Filter(new Domain.Entities.CourseClass { Id = id }).FirstOrDefault();
        }

        public ValidationResult Remove(Guid id)
        {
            var operationResult = _courseClassRepository.Remove(id);

            var response = new ValidationResult();

            if (!operationResult)
            {
                response.AddError("Classe não encontrada");
            }

            return response;
        }

        public ValidationResult Update(Domain.Entities.CourseClass entity)
        {
            var response = new ValidationResult();

            if (!entity.IsValid())
            {
                response.AddError(entity.Errors.ToArray());

                return response;
            }

            var subjectId = _curriculum_SubjectRepository.GetAll().FirstOrDefault(w => w.Id == entity.Curriculum_SubjectId)?.SubjectId;

            if (!subjectId.HasValue || !CheckIfSubjectIsEnabled(entity.Curriculum_SubjectId))
            {
                response.AddError("Disciplina não disponível");
            }

            if (!CheckIfProfessorIsAuthorized(entity.ProfessorId, subjectId.Value))
            {
                response.AddError($"Professor não habilitado para esta disciplina.");
            }

            var operationResult = _courseClassRepository.Update(entity);

            if (!operationResult)
            {
                response.AddError("Classe não encontrada");
            }

            return response;
        }
    }
}
