using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchSchool.Application
{
    public class Professor : IProfessor
    {
        private IProfessorRepository _professorRepository;
        private IPerson _person;
        private IStudentRepository _studentRepository;
        private ICourseClassRepository _courseClassRepository;

        public Professor(IProfessorRepository professorRepository,
                         IPerson person,
                         IStudentRepository studentRepository,
                         ICourseClassRepository courseClassRepository)
        {
            _professorRepository = professorRepository;
            _studentRepository = studentRepository;
            _person = person;
            _courseClassRepository = courseClassRepository;
        }


        public Domain.Entities.Professor Add(Domain.Entities.Professor entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Nenhuma informação de professor enviada");
            }

            if (!_person.CheckIfExists(entity.Person))
            {
                try
                {
                    _person.Add(entity.Person);
                    entity.PersonId = entity.Person.Id.Value;
                }
                catch (Exception ex)
                {
                    entity.AddError(ex.Message);
                    return entity;
                }
            }

            if (entity.RelatedSubjects.Any())
            {
                var validationResult = VerifyIfProfessorIsACurrentStudentFromClass(entity);

                if (validationResult.Errors.Any())
                {
                    entity.AddError(validationResult.Errors.ToArray());
                    return entity;
                }
            }

            _professorRepository.Add(entity);

            return entity;
        }

        private ValidationResult VerifyIfProfessorIsACurrentStudentFromClass(Domain.Entities.Professor entity)
        {
            var result = _courseClassRepository.GetRelatedSubjects(entity.PersonId)
                                               .Where(y =>
                                               {
                                                   return entity.RelatedSubjects.Select(t => t.SubjectId).Contains(y.Subject.Id.Value) &&
                                                          y.Student.Status == Domain.Enum.EEnrollmentStatus.ACTIVE;
                                               });

            var validationResult = new ValidationResult();

            foreach (var data in result)
            {
                validationResult.AddError($"O usuário {entity.Person.Name} não pode lecionar na disciplina {data.Subject.Name}, pois possui uma matrícula: {data.Student.EnrollmentID} em aberto como aluno nesta disciplina.");
            }

            return validationResult;
        }

        public IEnumerable<Domain.Entities.Professor> GetAll() => _professorRepository.GetAll();

        public Domain.Entities.Professor GetById(Guid id) => _professorRepository.Filter(new Domain.Entities.Professor { Id = id }).FirstOrDefault();

        public ValidationResult Remove(Guid id)
        {
            var operationResult = _professorRepository.Remove(id);

            if (!operationResult)
            {
                return new ValidationResult()
                {
                    Errors = new List<Shared.Validations.Error> {
                        new Shared.Validations.Error{ Message= "Nenhum professor encontrado com a chave informada."}
                    }
                };
            }

            return ValidationResult.GetEmptyResult();
        }

        public ValidationResult Update(Domain.Entities.Professor entity)
        {
            if (entity.RelatedSubjects.Any())
            {
                var validationResult = VerifyIfProfessorIsACurrentStudentFromClass(entity);

                if (validationResult.Errors.Any())
                {
                    entity.AddError(validationResult.Errors.ToArray());
                    return entity;
                }
            }

            _professorRepository.Update(entity);
            return new ValidationResult();
        }
    }
}
