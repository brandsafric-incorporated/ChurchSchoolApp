using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Enum;
using ChurchSchool.Repository.Contracts;
using ChurchSchool.Shared.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Application
{
    public class Student : IStudent
    {
        private EEnrollmentStatus[] StatusAvaiableToActivation => new EEnrollmentStatus[3] {
            EEnrollmentStatus.WAITING_APROVEMENT,
            EEnrollmentStatus.SUSPEND,
            EEnrollmentStatus.UNDEFINED
        };

        private EEnrollmentStatus[] StatusAvaiableToSuspension => new EEnrollmentStatus[3] {
            EEnrollmentStatus.WAITING_APROVEMENT,
            EEnrollmentStatus.ACTIVE,
            EEnrollmentStatus.UNDEFINED
        };

        private EEnrollmentStatus[] StatusAvaiableToConclusion => new EEnrollmentStatus[1] {
            EEnrollmentStatus.ACTIVE
        };

        private IStudentRepository _studentRepository;        
        private IPerson _person;

        public Student(IStudentRepository studentRepository,
                       IPerson person)
        {
            _studentRepository = studentRepository;
            _person = person;
        }

        public Domain.Entities.Student Add(Domain.Entities.Student entity)
        {
            if (!_person.CheckIfExists(entity.Person))
            {
                try
                {
                    _person.Add(entity.Person);
                }
                catch (Exception ex)
                {
                    entity.AddError(ex.Message);
                    return entity;
                }
            }

            if (VerifyStudentAlreadyEnrolled(entity))
            {
                entity.AddError("Estudante já matriculado");
                return entity;
            }

            //TODO INCLUIR VERIFICAÇÃO SE ESTUDANTE TENTANDO SE MATRICULAR É PROFESSOR NO CURSO
            entity.EnrollmentID = GenerateEnrollmentID(entity);

            entity.Status = EEnrollmentStatus.WAITING_APROVEMENT;

            _studentRepository.Add(entity);

            //check if the person is a professor
            return entity;
        }

        private string GenerateEnrollmentID(Domain.Entities.Student entity)
        {
            var enrollmentID = $"{DateTime.Now.Year}{(DateTime.Now.Month < 7 ? "01" : "02")}";

            return $"{enrollmentID}_{(_studentRepository.GetAll().Count(d => d.CourseId == entity.CourseId) + 1)}";
        }

        private bool VerifyStudentAlreadyEnrolled(Domain.Entities.Student entity)
        {
            var cpfInformed = entity.Person.Documents.FirstOrDefault(y => y.DocumentType == EDocumentType.CPF);

            if (cpfInformed == null)
                throw new Exception("CPF não informado");

            return _studentRepository.VerifyStudentAlreadyEnrolled(cpfInformed.DocumentNumber, entity.CourseId);
        }

        public IEnumerable<Domain.Entities.Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Domain.Entities.Student GetById(long id)
        {
            return _studentRepository.Filter(new Domain.Entities.Student { Id = id }).FirstOrDefault();
        }

        public ValidationResult Remove(long id)
        {
            var currentStudent = GetById(id);

            currentStudent.Status = EEnrollmentStatus.CANCELED;

            _studentRepository.Update(currentStudent);

            return new ValidationResult();
        }

        public ValidationResult Update(Domain.Entities.Student entity)
        {
            var currentStudent = GetById(entity.Id.Value);

            if (currentStudent == null)
                throw new ArgumentNullException("Estudante não encontrado na base de dados.");

            var validationResult = VerifyEnrollmentStatusChanges(currentStudent.Status, entity);

            if (validationResult.Errors.Any())
            {
                return validationResult;
            }

            if (StatusAvaiableToActivation.Contains(currentStudent.Status) && entity.Status == EEnrollmentStatus.ACTIVE)
            {
                entity.EnrollmentDate = DateTime.Now;
            }

            entity.EnrollmentID = currentStudent.EnrollmentID;

            _studentRepository.Update(entity);

            return new ValidationResult();
        }

        private bool VerifyIfStudentIsAllowedToCompleteCourse(Domain.Entities.Student entity)
        {
            //TODO - Implementar funcionalidade que checa se todas as disciplinas do curso foram cumpridas com a média de aprovação do curso vigente
            return false;
        }

        private ValidationResult VerifyEnrollmentStatusChanges(EEnrollmentStatus currentStatus, Domain.Entities.Student entity)
        {
            var validationResult = new ValidationResult();

            if (currentStatus != EEnrollmentStatus.WAITING_APROVEMENT && entity.Status == EEnrollmentStatus.WAITING_APROVEMENT)
            {
                entity.AddError("Não é possível configurar esta matricula como 'Aguardando Aprovação', pois ela já foi aprovada anteriormente");
                return validationResult;
            }

            if (currentStatus == EEnrollmentStatus.CANCELED && entity.Status != EEnrollmentStatus.CANCELED)
            {
                entity.AddError("Não é possível alterar o status de uma matricula cancelada.");
                return validationResult;
            }

            if (StatusAvaiableToSuspension.Contains(currentStatus) && entity.Status == EEnrollmentStatus.SUSPEND)
            {
                entity.AddError($"A matrícula {entity.EnrollmentID} não pode ser cancelada pois está no status {entity.Status}");
                return validationResult;
            }

            if ((!StatusAvaiableToConclusion.Contains(currentStatus) && entity.Status == EEnrollmentStatus.COMPLETED) || !VerifyIfStudentIsAllowedToCompleteCourse(entity))
            {
                //TODO - RETORNAR NESTE MÉTODO AS PENDÊNCIAS
                entity.AddError($"A matrícula {entity.EnrollmentID} não pode ser concluída pois ainda restam pendências a serem resolvidas.");
                return validationResult;
            }

            return validationResult;
        }
    }
}
