using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Application.App
{
    public class CourseConfiguration : ICourseConfiguration
    {
        private ICourseConfigurationRepository _courseConfigurationRepository;

        private ICourseRepository _courseRepository;

        private ICourseDocumentRepository _courseDocumentRepository;

        public CourseConfiguration(ICourseConfigurationRepository courseConfigurationRepository,
                                   ICourseRepository courseRepository,
                                   ICourseDocumentRepository courseDocumentRepository)
        {
            _courseConfigurationRepository = courseConfigurationRepository;
            _courseRepository = courseRepository;
            _courseDocumentRepository = courseDocumentRepository;
        }

        public IEnumerable<Domain.Entities.CourseConfiguration> GetAll()
        {
            return _courseConfigurationRepository.GetAll();
        }

        public Domain.Entities.CourseConfiguration Add(Domain.Entities.CourseConfiguration entity)
        {
            if (!entity.IsValid())
                return entity;

            if (entity.IsCurrentConfiguration)
            {
                try
                {
                    DisableCurrentConfiguration(entity);
                }
                catch (Exception ex)
                {
                    entity.AddError(ex.Message);
                    return entity;
                }
            }

            return _courseConfigurationRepository.Add(entity);
        }

        public Domain.Entities.CourseConfiguration GetById(Guid id)
        {
            return _courseConfigurationRepository.Filter(new Domain.Entities.CourseConfiguration { Id = id })
                                                 .FirstOrDefault();

        }

        public IEnumerable<Domain.Entities.CourseConfiguration> GetByCourse(Guid courseId)
        {
            return _courseConfigurationRepository.Filter(new Domain.Entities.CourseConfiguration { CourseId = courseId });
        }

        public ValidationResult Remove(Guid id)
        {
            if (VerifyRelatedCourses(id))
            {
                var validation = new ValidationResult();
                validation.AddError("Existem cursos ativos atrelados a esta configuração, mude a configuração nos cursos e tente novamente.");
                return validation;
            }

            _courseConfigurationRepository.Remove(id);

            return new ValidationResult();
        }

        public ValidationResult Update(Domain.Entities.CourseConfiguration entity)
        {
            if (entity == null)
            {
                var result = new ValidationResult();
                result.AddError("Nenhuma configuraçao de curso informada para atualização.");
                return result;
            }

            if (!entity.IsValid())
                return entity;

            if (entity.IsCurrentConfiguration)
            {
                try
                {
                    DisableCurrentConfiguration(entity);
                }
                catch (Exception ex)
                {
                    entity.AddError(ex.Message);
                    return entity;
                }
            }

            entity.UpdatedDate = DateTime.Now;

            _courseDocumentRepository.RemoveByCourseConfiguration(entity.Id.Value);

            _courseConfigurationRepository.Update(entity);

            return new ValidationResult();
        }



        private bool VerifyRelatedCourses(Guid id)
        {
            var result = _courseConfigurationRepository.Filter(new Domain.Entities.CourseConfiguration { Id = id });

            return (result != null && result.Any(y => y.RelatedCourse != null));
        }

        private void DisableCurrentConfiguration(Domain.Entities.CourseConfiguration entity)
        {
            var course = _courseRepository.Filter(new Domain.Entities.Course { Id = entity.CourseId }).FirstOrDefault();

            if (course != null)
            {
                if (course.RemovedDate != null)
                {
                    throw new Exception("Não é possível adicionar uma configuração a um curso desabilitado");
                }

                var configurations = _courseConfigurationRepository.GetByCourse(entity.CourseId);

                foreach (var configuration in configurations)
                {
                    configuration.IsCurrentConfiguration = false;
                }

                course.CurrentConfiguration = entity;
                _courseRepository.Update(course);
            }
        }
    }
}
