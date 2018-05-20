using ChurchSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSchool.Domain.Contracts
{
    public interface IPersonDocumentRepository
    {
        /// <summary>
        /// Receives a list of documents and check if any of them is already saved on db
        /// </summary>
        /// <param name="documents">Person document list</param>
        /// <returns>A boolean value indicating if some document is saved (true) or not (false)</returns>
        bool CheckIfDocumentIsRegistered(IEnumerable<PersonDocument> documents);
    }
}
