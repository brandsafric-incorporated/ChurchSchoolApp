using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchSchool.Application.App
{
    public class Professor : IProfessor
    {
        private IProfessorRepository _professorRepository;
        private IPerson _person;
        private IStudentRepository _studentRepository;

        public Professor(IProfessorRepository professorRepository, IPerson person, IStudentRepository studentRepository)
        {
            _professorRepository = professorRepository;
            _studentRepository = studentRepository;
            _person = person;
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

            var validationResult = VerifyIfProfessorIsACurrentStudentFromClass(entity);

            if (validationResult.Errors.Any())
            {
                entity.AddError("A pessoa informada é uma aluna corrente, ela não pode ser cadastrada como professora no momento. ");
                return entity;
            }

            _professorRepository.Add(entity);

            return entity;
        }

        private ValidationResult VerifyIfProfessorIsACurrentStudentFromClass(Domain.Entities.Professor entity)
        {
            //var result = _studentRepository.GetStudentBySubject(entity.RelatedSubjects.Select(s => s.SubjectId));

            var validationResult = new ValidationResult();

            //foreach (var data in result.Where(x => x.Student.Status == Domain.Enum.EEnrollmentStatus.ACTIVE && x.Student.PersonId == entity.PersonId))
            //{
            //    validationResult.AddError($"O usuário {entity.Person.Name} não pode lecionar na disciplina {data.RelatedClass.Curriculum_Subject.Subject.Name}, pois possui matrícula em aberto como aluno nesta disciplina.");
            //}

            return validationResult;
        }

        public IEnumerable<Domain.Entities.Professor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Professor GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Update(Domain.Entities.Professor entity)
        {
            throw new NotImplementedException();
        }
    }
}
