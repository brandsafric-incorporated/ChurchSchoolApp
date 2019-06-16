﻿using System;
using System.Collections.Generic;
using System.Linq;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;

namespace ChurchSchool.Application
{
    public class Person : IPerson
    {
        private readonly IPersonRepository _personRepository;

        public Person(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Domain.Entities.Person Add(Domain.Entities.Person entity)
        {
            if (!entity.IsValid())
            {
                return entity;
            }

            var newPersonCpf = entity.Documents.FirstOrDefault(x => x.DocumentType == Domain.Enum.EDocumentType.CPF);

            if (newPersonCpf == null)
            {
               entity.AddError($"CPF não encontrado - Pessoa a ser cadastrada: {entity.FirstName} {entity.MiddleName} {entity.LastName} ");
               return entity;
            }

            //TODO - validate all documents, in a later moment
            if (_personRepository.GetByCPF(newPersonCpf.DocumentNumber) != null)
            {
               entity.AddError($"CPF {newPersonCpf.DocumentNumber} já cadastrado");
               return entity;
            }

            _personRepository.Add(entity);

            return entity;
        }

        public bool CheckIfExists(Domain.Entities.Person person)
        {
            var newPersonCpf = person.Documents.FirstOrDefault(x => x.DocumentType == Domain.Enum.EDocumentType.CPF);

            return newPersonCpf != null && _personRepository.GetByCPF(newPersonCpf.DocumentNumber) != null;
        }

        public IEnumerable<Domain.Entities.Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        public Domain.Entities.Person GetById(long id)
        {
            return _personRepository.Filter(new Domain.Entities.Person { Id = id })
                                    .FirstOrDefault();
        }

        public ValidationResult Remove(long id)
        {
            _personRepository.Remove(id);
            return new ValidationResult();
        }

        public ValidationResult Update(Domain.Entities.Person entity)
        {
            if (!entity.IsValid())
            {
                return entity;
            }

            var newPersonCpf = entity.Documents.FirstOrDefault(x => x.DocumentType == Domain.Enum.EDocumentType.CPF);

            if (newPersonCpf == null)
            {
                entity.AddError($"CPF não encontrado - Pessoa a ser cadastrada: {entity.FirstName}");
                return entity;
            }

            var currentSavedCpf = _personRepository.GetByCPF(newPersonCpf.DocumentNumber);

            //TODO - validate all documents, in a later moment
            if (currentSavedCpf != null && currentSavedCpf.Id != entity.Id)
            {
                entity.AddError($"CPF {newPersonCpf.DocumentNumber} já cadastrado");
                return entity;
            }

            _personRepository.Update(entity);

            return entity;
        }

        private ValidationResult ValidateForDelete(long personId)
        {
            //TODO - Implement Validation for Delete, looking situations as Person is already a enrolled student, Person is a person acting as professor
            return new ValidationResult();
        }
        
    }
}
