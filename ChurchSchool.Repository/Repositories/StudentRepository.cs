using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Repository.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private RepositoryContext _context;
        private IPersonRepository _personRepository;

        public StudentRepository(RepositoryContext context, IPersonRepository personRepository)
        {
            _context = context;
            _personRepository = personRepository;
        }

        public Student Add(Student model)
        {
            model.InsertedDate = DateTime.Now;
            _context.Students.Add(model);
            return model;
        }

        public IEnumerable<Student> Filter(Student model)
        {
            return _context.Students.Where(x => x == model)
                                    .ToList();

        }

        public IEnumerable<Student> GetAll() => _context.Students.ToList();



        public bool Remove(Guid key)
        {
            var itemToRemove = _context.Students.Find(key);

            _context.Students.Remove(itemToRemove);

            return true;
        }

        public bool Update(Student model)
        {
            model.UpdatedDate = DateTime.Now;
            _context.Update(model);
            return true;
        }

        public bool VerifyStudentAlreadyEnrolled(string cpf, Guid courseId)
        {
            var person = _personRepository.GetByCPF(cpf);

            if (person == null)
                return false;

            var exists = (from x in _context.Students
                          where x.PersonId == person.Id
                          select x).Any();

            return exists;
        }
    }
}
