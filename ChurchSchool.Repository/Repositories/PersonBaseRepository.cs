using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSchool.Repository.Repositories
{
    public abstract class PersonBaseRepository
    {
        /*
        private readonly IPersonRepository _personRepository;
        private readonly RepositoryContext _repositoryContext;
        public PersonBaseRepository(IPersonRepository personRepository, RepositoryContext repositoryContext)
        {
            _personRepository = personRepository;
            _repositoryContext = repositoryContext;
        }

        public Person FindByDocument(Document document, ERole personType)
        {
            if (document == null)
                throw new ArgumentNullException("Document Information not provided, object received is null");


            var result = _repositoryContext.People.FirstOrDefault(p =>
                        p.PersonDocuments.Any(pd => pd.DocumentNumber.Trim().ToLower() == document.DocumentNumber && pd.DocumentTypeId == document.DocumentTypeId)
            );

            return result;
        }
        */
    }
}