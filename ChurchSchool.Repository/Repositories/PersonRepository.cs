using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Enum;
using ChurchSchool.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Repository.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private RepositoryContext _context;

        public PersonRepository(RepositoryContext context)
        {
            _context = context;
        }

        public Person Add(Person model)
        {
            var now = DateTime.Now;

            model.InsertedDate = now;

            foreach (var address in model.Addresses)
            {
                address.InsertedDate = now;
            }

            foreach (var phone in model.Phones)
            {
                phone.InsertedDate = now;
            }

            foreach (var doc in model.Documents)
            {
                doc.InsertedDate = now;
            }

            _context.People.Add(model);

            return model;
        }

        public IEnumerable<Person> Filter(Person model)
        {
            return _context.People.Where(p => p.Id == model.Id);
        }

        public IEnumerable<Person> GetAll() => _context.People;

        public Person GetByCPF(string cpfNumber)
        {
            var result = _context.People
                                 .Include(x => x.Documents)
                                 .Include(x => x.Phones)
                                 .Include(x => x.Addresses)
                                 .Include(x => x.Phones)
                                 .Include(x => x.Email)
                                 .FirstOrDefault(y => y.Documents.Any(x => x.DocumentTypeId == EDocumentType.CPF && Convert.ToInt64(x.DocumentNumber) == Convert.ToInt64(cpfNumber)));
            return result;
        }

        public bool Remove(long key)
        {
            var person = _context.People.FirstOrDefault(x => x.Id == key);

            if (person != null)
            {
                _context.People.Remove(person);
                return true;
            }

            return false;
        }

        public bool Update(Person model)
        {
            var now = DateTime.Now;

            model.UpdatedDate = now;

            foreach (var address in model.Addresses)
            {
                address.UpdatedDate = now;
            }

            foreach (var phone in model.Phones)
            {
                phone.UpdatedDate = now;
            }

            foreach (var doc in model.Documents)
            {
                doc.UpdatedDate = now;
            }

            model.UpdatedDate = DateTime.Now;
            _context.People.Update(model);
            return true;

        }
    }
}
