using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchSchool.Repository.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private RepositoryContext _repository;

        public PersonRepository(RepositoryContext repository)
        {
            _repository = repository;
        }

        public Person Add(Person model)
        {
            _repository.Add(model);
            _repository.SaveChanges();

            return model;
        }

        public IEnumerable<Person> Filter(Person model)
        {
            var results = _repository.People.AsNoTracking().Where(p => p.Id == model.Id);
            return results;
        }

        public IEnumerable<Person> GetAll()
        {
            return _repository.People.AsNoTracking();
        }

        public Person GetByCPF(string cpfNumber)
        {
            return _repository.People.AsNoTracking()
                                     .SingleOrDefault(x => x.PersonDocuments.Any(doc => doc.DocumentTypeId == Domain.Enum.EDocumentType.CPF && doc.DocumentNumber == cpfNumber));
        }

        public bool Remove(Guid key)
        {
            var person = _repository.People.AsNoTracking().FirstOrDefault(x => x.Id == key);

            if (person != null)
            {
                _repository.People.Remove(person);
                _repository.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Update(Person model)
        {
            model.UpdatedDate = DateTime.Now;
            _repository.People.Update(model);
            _repository.SaveChanges();
            return true;
        }
    }
}
