using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Shared.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChurchSchool.Application.App
{
    public class Student 
    {
        private IStudentRepository _studentRepository;
        private IProfessorRepository _professorRepository;
        private IPersonDocumentRepository _personDocumentRepository;

        public Student(IStudentRepository studentRepository,
                       IProfessorRepository professorRepository,
                       IPersonDocumentRepository personDocumentRepository)
        {
            _studentRepository = studentRepository;
            _professorRepository = professorRepository;
            _personDocumentRepository = personDocumentRepository;
        }

        public Task<Domain.Entities.Student> Add(Domain.Entities.Student entity)
        {

            //check if any document is already in use


            //check if the person is a professor
            return null;
        }

        public IEnumerable<Domain.Entities.Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Student GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Domain.Entities.Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
