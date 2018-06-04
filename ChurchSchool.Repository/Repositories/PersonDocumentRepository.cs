using ChurchSchool.Domain.Contracts;
using ChurchSchool.Domain.Entities;
using System.Collections.Generic;

namespace ChurchSchool.Repository.Repositories
{

    public class PersonDocumentRepository : IPersonDocumentRepository
    {
        private RepositoryContext _repositoryContext;

        public PersonDocumentRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public bool CheckIfDocumentIsRegistered(IEnumerable<PersonDocument> documents)
        {
            //var exists = (from dbDocument in _repositoryContext.PersonDocuments                         
            //              join doc in documents on dbDocument.DocumentNumber.Trim().ToLower() equals doc.DocumentNumber.Trim().ToLower()
            //              select new
            //              {
            //                  dbDocument.PersonId,
            //                  dbDocument.DocumentNumber,
            //                  dbDocument.DocumentTypeId
            //              }
            //              ).Any();


            return false;            
        }
    }

}
