using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Application
{
    public class CourseClass : ICourseClass
    {
        private ICourseClassRepository _courseClassRepository;
        private IProfessorSubjectRepository _professorSubjectRepository;
        private ICourseSubjectRepository _course_SubjectRepository;

        public CourseClass(ICourseClassRepository courseClassRepository,
                           IProfessorSubjectRepository professorSubjectRepository,
                           ICourseSubjectRepository course_SubjectRepository
                           )
        {
            _courseClassRepository = courseClassRepository;
            _course_SubjectRepository = course_SubjectRepository;
            _professorSubjectRepository = professorSubjectRepository;
        }

        public Domain.Entities.CourseClass Add(Domain.Entities.CourseClass entity)
        {
            if (!entity.IsValid())
            {
                return entity;
            }

            var subjectId = _course_SubjectRepository.GetAll().FirstOrDefault(w => w.Id == entity.Course_SubjectId)?.SubjectId;

            if (!subjectId.HasValue || !CheckIfSubjectIsEnabled(entity.Course_SubjectId.Value))
            {
                entity.AddError("Disciplina não disponível");
            }

            if (!CheckIfProfessorIsAuthorized(entity.ProfessorId ?? default(Guid), subjectId.Value))
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
        private bool CheckIfSubjectIsEnabled(Guid courseSubjectId)
        {
            var isSubjectEnabled = _course_SubjectRepository.Filter(
                new Course_Subject { Id = courseSubjectId }
            ).Any(x => x.CourseConfiguration.FinishDate != null);

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

            var subjectId = _course_SubjectRepository.GetAll().FirstOrDefault(w => w.Id == entity.Course_SubjectId)?.SubjectId;

            if (!subjectId.HasValue || !CheckIfSubjectIsEnabled(entity.Course_SubjectId.Value))
            {
                response.AddError("Disciplina não disponível");
            }

            if (!CheckIfProfessorIsAuthorized(entity.ProfessorId.Value, subjectId.Value))
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
