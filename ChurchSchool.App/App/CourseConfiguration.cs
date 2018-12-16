using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Application
{
    public class CourseConfiguration : ICourseConfiguration
    {
        private ICourseConfigurationRepository _courseConfigurationRepository;
        private ICourseRepository _courseRepository;
        private ICourseDocumentRepository _courseDocumentRepository;
        private ISubjectRepository _subjectRepository;


        public CourseConfiguration(ICourseConfigurationRepository courseConfigurationRepository,
                                   ICourseRepository courseRepository,
                                   ICourseDocumentRepository courseDocumentRepository,                                   
                                   ISubjectRepository subjectRepository)
        {
            _courseConfigurationRepository = courseConfigurationRepository;
            _courseRepository = courseRepository;
            _courseDocumentRepository = courseDocumentRepository;
            _subjectRepository = subjectRepository;
        }

        public IEnumerable<Domain.Entities.CourseConfiguration> GetAll() => _courseConfigurationRepository.GetAll();

        public Domain.Entities.CourseConfiguration Add(Domain.Entities.CourseConfiguration entity)
        {
            if (!entity.IsValid())
                return entity;

            if((bool)entity.EnrollDocuments?.Any())
            {
                _courseDocumentRepository.AddCourseDocumentRange(entity.EnrollDocuments);
            }

            entity.EnrollDocuments = null;

            return _courseConfigurationRepository.Add(entity);
        }

        //public Domain.Entities.CourseConfiguration GetById(Guid id)
        //{
        //    return _courseConfigurationRepository.Filter(new Domain.Entities.CourseConfiguration { Id = id })
        //                                         .FirstOrDefault();

        //}

        public IEnumerable<Domain.Entities.CourseConfiguration> GetByCourse(long courseId) => _courseConfigurationRepository.GetByCourse(courseId);


        //public ValidationResult Remove(Guid id)
        //{
        //    if (VerifyRelatedCourses(id))
        //    {
        //        var validation = new ValidationResult();
        //        validation.AddError("Existem cursos ativos atrelados a esta configuração, mude a configuração nos cursos e tente novamente.");
        //        return validation;
        //    }

        //    _courseConfigurationRepository.Remove(id);

        //    return new ValidationResult();
        //}

        //public ValidationResult Update(Domain.Entities.CourseConfiguration entity)
        //{
        //    if (entity == null)
        //    {
        //        var result = new ValidationResult();
        //        result.AddError("Nenhuma configuraçao de curso informada para atualização.");
        //        return result;
        //    }

        //    if (!entity.IsValid())
        //        return entity;

        //    //if (entity.IsCurrentConfiguration)
        //    //{
        //    //    try
        //    //    {
        //    //        DisableCurrentConfiguration(entity);
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        entity.AddError(ex.Message);
        //    //        return entity;
        //    //    }
        //    //}

        //    entity.UpdatedDate = DateTime.Now;

        //    _courseDocumentRepository.RemoveByCourseConfiguration(entity.Id.Value);

        //    _courseConfigurationRepository.Update(entity);

        //    return new ValidationResult();
        //}

        //private bool VerifyRelatedCourses(Guid id)
        //{
        //    var result = _courseConfigurationRepository.Filter(new Domain.Entities.CourseConfiguration { Id = id });

        //    return (result != null && result.Any(y => y.RelatedCourse != null));
        //}

        //public ValidationResult VinculateSubject(Domain.Entities.Course_Subject model)
        //{
        //    var configuration = _courseConfigurationRepository.Get(model.ConfigurationCourseId.Value);
        //    var result = new ValidationResult();
        //    var subject = _subjectRepository.Filter(new Domain.Entities.Subject { Id = model.SubjectId });

        //    if (configuration == null)
        //    {
        //        result.AddError("Configuração não encontrada.");
        //    }

        //    if (subject == null)
        //    {
        //        result.AddError("Matéria não encontrada.");
        //    }


        //    if (!result.Errors.Any())
        //    {
        //        _courseSubjectRepository.Add(model);
        //    }

        //    return result;
        //}

        public Domain.Entities.CourseConfiguration GetById(long id)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Remove(long id)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Update(Domain.Entities.CourseConfiguration entity)
        {
            throw new NotImplementedException();
        }

        //public ValidationResult VinculateSubject(Course_Subject model)
        //{
        //    throw new NotImplementedException();
        //}

        //public ValidationResult VinculateSubject(Domain.Entities.Course_Subject model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
